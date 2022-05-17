import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { PostfeedApiService } from 'src/app/postfeed-api.service.service';


@Component({
  selector: 'app-show-postfeed',
  templateUrl: './show-postfeed.component.html',
  styleUrls: ['./show-postfeed.component.css']
})
export class ShowPostfeedComponent implements OnInit {

  postfeedList$!:Observable<any[]>;
  postfeedTypesList$!:Observable<any[]>;
  postTypesList:any=[];


  postTypesMap:Map<number, string> = new Map()
  constructor(private service:PostfeedApiService) { }


  ngOnInit(): void {
    this.postfeedList$ = this.service.getPostfeedList();


  }

}
