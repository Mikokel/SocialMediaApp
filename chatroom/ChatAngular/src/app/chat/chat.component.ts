import { Component, Input, OnInit, OnDestroy } from '@angular/core';

import { AuthService, User } from '@auth0/auth0-angular';

import { Subscription } from 'rxjs';

import { SignalRClientService } from '../signal-rclient.service';
import { ReceiveMessage } from '../receivemessage';
import { ChatUser } from '../user';


@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.css']
})
export class ChatComponent implements OnInit, OnDestroy {
  message: string = '';
  userSender: ChatUser = { };
  defaultReceiver: ChatUser = { name: 'All' };
  userReceiver: ChatUser = this.defaultReceiver;
  //loggedInUser?: User;
  userName: string = 'peter';
  chatContainer: ReceiveMessage[] = [];
  onlineUsers: ChatUser[] = [];
  subscription: Subscription;

  constructor(
    public auth: AuthService,
    private signalrClientService: SignalRClientService)
  {
    this.auth.getUser().subscribe( u => { this.userSender.name = u?.nickname; } );
    console.log("logging 1: this.userSender.name = "+this.userSender.name);
    this.subscription = new Subscription();
    this.subscription.add(this.signalrClientService.messenger.subscribe((res: ReceiveMessage) => {
      this.chatContainer.push(res);
    }));
    this.subscription.add(this.signalrClientService.onlineUsers.subscribe((res: ChatUser[]) => {
      this.onlineUsers = res;
    }));
  }

  ngOnInit(): void {
    this.auth.getUser<User>().subscribe( u => {
      console.log(JSON.stringify(u)); 
      this.connectHub(u?.nickname);
    });
    
  }
  ngOnDestroy(): void {
    this.subscription.unsubscribe();
    this.signalrClientService.closeConnection();
  }
  
  connectHub(name?: string) {
    
    this.signalrClientService.openConnection(name);
  }
  onSendMessage() {
    this.signalrClientService.sendMessage(this.userReceiver.name, this.userSender.name, this.message).then(res => {
      //this.chatContainer.push({ message: this.message, sender: this.signalrClientService.userName, receiver: this.signalrClientService.userName, isSender: true })
    });
  }
  onSelectReceiver(user: ChatUser) {
    if (this.userReceiver.name == 'All') {
      this.userReceiver = user;
    } else if (this.userReceiver.name == user.name) {
      this.userReceiver = this.defaultReceiver;
    } else {
      this.userReceiver = user;
    }
  }
  
}
