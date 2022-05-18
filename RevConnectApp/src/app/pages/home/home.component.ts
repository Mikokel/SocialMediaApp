import { Component, OnInit } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  Auth0_ID !:any;
 
  constructor(public auth: AuthService) {}
    
  ngOnInit(): void {
   
    this.auth.user$.subscribe( (profile) => (this.Auth0_ID= profile?.sub)
    
    );
    
  }

}
