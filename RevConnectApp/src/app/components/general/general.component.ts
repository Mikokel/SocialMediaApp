import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { UserSocial } from 'src/app/Interfaces/UserSocial'
import { AuthService, User } from '@auth0/auth0-angular';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-general',
  templateUrl: './general.component.html',
  styleUrls: ['./general.component.css']
})
export class GeneralComponent implements OnInit {
  @Output() onSubmitPicture: EventEmitter<UserSocial>=new EventEmitter();
  picture!:any;
  user!:any;
  userSocial!:UserSocial;

  constructor(private api:ApiService, public auth:AuthService) { }

  ngOnInit(): void {
    this.auth.user$.subscribe((data)=>this.user=data)
  }

  getUserProfile(){
    this.api.getCurrentUser(this.user.sub).subscribe((data)=>this.userSocial=data);
    console.log(this.userSocial);
  }

  updateUserPicture(photo:any){
    this.api.postPicture(photo).subscribe((data)=>this.user=data);
  }

  updateUsername(userSocial:UserSocial){
    this.api.updateUsername(userSocial).subscribe((data)=>this.user=data);
    console.log(userSocial);
  }

  updateAboutMe(userSocial:UserSocial){
    this.api.updateAboutMe(userSocial).subscribe((data)=>this.user=data);
    console.log(userSocial);
  }

}