import { Component, OnInit } from '@angular/core';
import { HttpClient, JsonpClientBackend, HttpHeaders} from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { Form, FormBuilder } from '@angular/forms';


const headers= new HttpHeaders()
  .set('content-type', 'application/json')
  .set('Access-Control-Allow-Origin', '*');

  export class Comment {
    constructor(
      public ID: number,
      public Body: any,
      public TimeStamp: any
    )
    {}
  }

@Component({
  selector: 'app-comment',
  templateUrl: './comment.component.html',
  styleUrls: ['./comment.component.css']
})

@Injectable()
export class CommentComponent implements OnInit{
  
currentComment : Comment = new Comment(0, "", "");


constructor(private httpClient: HttpClient) { }
  comment = "Angular";
  postComment = [] as any[];
  
  post () {
    this.postComment.push(this.comment);
    this.comment = "";
    }

   async createComment(buttoninput:string)
     {
      if(this.comment)
      {
        this.httpClient.post(`https://localhost:7232/api/Comment/ipaddress/${this.currentComment}`, (this.currentComment)).subscribe();
      }
   }
    ngOnInit(): void {
      throw new Error('Method not implemented.');
    }
  
}

