import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class PostfeedApiService {

  readonly postfeedAPIUrl = "https://localhost:7140/api"
  constructor(private http:HttpClient) { }



getPostfeedList():Observable<any[]> {
  return this.http.get<any>(this.postfeedAPIUrl + '/Posts');
}

addPostfeed(data:any) {
  return this.http.post(this.postfeedAPIUrl + '/Posts', data);
}

updatePostfeed(id:number|string, data:any) {
  return this.http.put(this.postfeedAPIUrl + `/Posts/${id}`, data);
}

deletePostfeed(id:number|string) {
  return this.http.delete(this.postfeedAPIUrl + `/Posts/${id}`);
}


// // Inspection Types
// getInspectionTypesList():Observable<any[]> {
//   return this.http.get<any>(this.inspectionAPIUrl + '/inspectionTypes');
// }

// addInspectionTypes(data:any) {
//   return this.http.post(this.inspectionAPIUrl + '/inspectionTypes', data);
// }

// updateInspectionTypes(id:number|string, data:any) {
//   return this.http.put(this.inspectionAPIUrl + `/inspectionTypes/${id}`, data);
// }

// deleteInspectionTypes(id:number|string) {
//   return this.http.delete(this.inspectionAPIUrl + `/inspectionTypes/${id}`);
// }

// // Like Statuses
// getStatusList():Observable<any[]> {
//   return this.http.get<any>(this.inspectionAPIUrl + '/status');
// }

// addStatus(data:any) {
//   return this.http.post(this.inspectionAPIUrl + '/status', data);
// }

// updateStatus(id:number|string, data:any) {
//   return this.http.put(this.inspectionAPIUrl + `/status/${id}`, data);
// }

// deleteStatus(id:number|string) {
//   return this.http.delete(this.inspectionAPIUrl + `/status/${id}`);
// }



}
