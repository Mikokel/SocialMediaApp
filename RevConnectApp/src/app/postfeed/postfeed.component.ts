import { HttpClient, JsonpClientBackend } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

export class Post{
  constructor(
  public postID: any,
  public body: any,
  public date: any,
  public image : any,
  public postComment: any,
  public postLikes: any
  )
{}
  }
@Component({
  selector: 'app-postfeed',
  templateUrl: './postfeed.component.html',
  styleUrls: ['./postfeed.component.css']
})
export class aPostfeedComponent implements OnInit {

public posts: Array<any> =[];  
  constructor( private httpClient: HttpClient ) 
  {
   }
   getPosts()
  {
    this.httpClient.get<any>('https://localhost:7161/api/Posts').subscribe(
      response => {
      console.log(response);
      for (let index = 0; index < response.length; index++) {
        this.posts.push(new Post(response[index].postID, response[index].body, response[index].date, response[index].image, response[index].postComment,response[index].postLikes));
      }
    });
  }

  ngOnInit(): void {
    this.getPosts;
  }

}
