import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AuthService } from '@auth0/auth0-angular';
import { Router } from '@angular/router';
import { Location } from '@angular/common'; 

@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html',
  styleUrls: ['./settings.component.css']
})
export class SettingsComponent implements OnInit {
  
  postedFile!: File ;
  
  
  path !:any;
  user !:any;
  Auth0_ID : any;
  constructor(private http: HttpClient,public auth: AuthService, public _router: Router, public _location: Location ) { }

  ngOnInit(): void {
    
    this.auth.user$.subscribe( (profile) => (this.Auth0_ID=this.user = profile?.sub)
    
    );
    console.log(this.Auth0_ID);
    

  }
  
//   showpics(Auth0_ID: string ):void{
//     this.http.get('https://localhost:7027/api/test_image/pet?Auth0_ID='+Auth0_ID).subscribe( (image:any) => { this.path = image[0].path; 
//     console.log(this.path[0].path);
//     console.log(Auth0_ID);
    
    
//       });
    
// }


  onFileSelected(event: any) 
  {
    this.postedFile=<File>event.target.files[0]; 
    
   
    
  }

  onUpload(){
    const Form_Data = new FormData();
    Form_Data.append('postedFile', this.postedFile,this.user);
    this.http.post('https://localhost:7027/api/test_image/images?Auth0_ID='+this.user,Form_Data).subscribe(res =>{console.log(res)});
    
  }

  onUpdate(){
   
    const Form_Data = new FormData();
    Form_Data.append('postedFile', this.postedFile,this.postedFile.name);
    this.http.put('https://localhost:7027/api/test_image/edit?Auth0_ID='+this.user,Form_Data).subscribe(res =>{console.log(res)});
    this.refresh();
  }


  all(){

    this.onUpload();
   // this.showpics(this.Auth0_ID);
     this.refresh();

  }
 

  refresh():void{
  
  

   window.location.reload();
  }

}
