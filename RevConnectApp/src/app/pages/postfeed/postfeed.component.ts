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
export class Like{
  constructor(
    public likeID: any,
    public userID: any,
    public postID: any,
    public commentID: any
  )
  {}
}
export class Comment{
  constructor(
    public commentID: any,
    public body: any,
    public date: any,
    public commentLikes: any,
    public postID: any,
    public userID: any
  )
  {}
}
@Component({
  selector: 'app-postfeed',
  templateUrl: './postfeed.component.html',
  styleUrls: ['./postfeed.component.css']
})


export class PostfeedComponent implements OnInit {
public posts: Array<any> =[];  
public likes: Array<any> = [];
public comments: Array<any> = [];
  constructor( private httpClient: HttpClient ) 
  {}
   
   getPosts()
    {
      this.httpClient.get<any>('https://localhost:7140/api/Posts').subscribe(
        response => {
        console.log("Posts:");
        console.log(response);
        for (let index = 0; index < response.length; index++)
        {
          this.posts.push(new Post(response[index].postID, response[index].body, response[index].date, response[index].image, response[index].postComment,response[index].postLikes));
        }
      });
    }
  getLikes()
  {
    this.httpClient.get<any>('https://localhost:7140/api/Like').subscribe(
      response => {
        console.log("Likes:");
        console.log(response);
        for (let index = 0; index < response.length; index++)
        {
          this.likes.push(new Like(response[index].likeID, response[index].userID, response[index].postID, response[index].commentID))
        }
      });
  }
  getComments()
  {
    this.httpClient.get<any>('https://localhost:7140/api/Comment').subscribe(
      response => {
        console.log("Comments:");
        console.log(response);
        for (let index = 0; index < response.length; index++)
        {
          this.comments.push(new Comment(response[index].commentID, response[index].body, response[index].date, response[index].commentLikes, response[index].postID, response[index].userID))
        }
      });
  }

  // onheartclick needs log in capabilties before implementation

    onHeartClick(selectedElement:any)
    {
      const heart = document.getElementById(selectedElement);
      // if(heart.className == )
      // this.httpClient.post<any>('https://localhost:7140/api/Posts').subscribe()
    }

    ngOnInit(): void {
      this.getPosts();
      this.getLikes();
      this.getComments();
    }

}
