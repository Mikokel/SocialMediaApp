import { Component, OnInit } from '@angular/core';
import { HttpClient, JsonpClientBackend, HttpHeaders} from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { Form, FormBuilder } from '@angular/forms';


const headers= new HttpHeaders()
  .set('content-type', 'application/json')
  .set('Access-Control-Allow-Origin', '*');

@Component({
  selector: 'app-comment',
  templateUrl: './comment.component.html',
  styleUrls: ['./comment.component.css']
})

@Injectable()
export class CommentComponent { 

constructor(private httpClient: HttpClient) { }
  comment = "";
  postComment = [] as any[];
  
  post () {
    this.postComment.push(this.comment);
    const headers = { 'content-type': 'application/json'}  
    let body ={ "body": this.comment};
    const body1=JSON.stringify(body);
    
    console.log(body1)
  
    const url ='https://localhost:7232/api/Comment/'
    this.http.post(url,body1,{'headers':headers})
  .subscribe((res)=>{
      
      console.log()  
    })

    this.comment = "";

    } 
}

