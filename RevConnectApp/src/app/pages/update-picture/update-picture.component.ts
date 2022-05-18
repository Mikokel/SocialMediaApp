import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';

@Component({
  selector: 'app-update-picture',
  templateUrl: './update-picture.component.html',
  styleUrls: ['./update-picture.component.css']
})
export class UpdatePictureComponent implements OnInit {
  @Input() path1!:any ;
  path !: any;
  
  constructor(private http: HttpClient,public auth: AuthService) { }

  ngOnInit(): void {
    this.http.get('https://localhost:7027/api/test_image/pet?Auth0_ID='+this.path1).subscribe( (image:any) => { this.path = image[0].path; 
    console.log(this.path[0].path);
    console.log(this.path1);
    
    
      })
  }

//   showpics(Auth0_ID: string ){
//     this.http.get('https://localhost:7027/api/test_image/pet?Auth0_ID='+Auth0_ID).subscribe( (image:any) => { this.path = image[0].path; 
//       console.log(this.path[0].path);
//     console.log(Auth0_ID);
    
//       })
    
// }

}
