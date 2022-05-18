import { Component, Input, OnInit } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {
  profileJson!: string; 
  @Input()url! : any ;
  Auth0_ID !:any;
 
  constructor(public auth: AuthService) {}
    
  ngOnInit(): void {
   
    this.auth.user$.subscribe( (profile) => (this.Auth0_ID= profile?.sub)
    
    );
    
  }

}
