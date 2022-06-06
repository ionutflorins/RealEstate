import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class ProjectApiService {

  readonly projectApiUrl = "https://localhost:7136/api/Project";

  constructor(private http:HttpClient) { }

  getProjectList():Observable<any[]>{
    return this.http.get<any>(this.projectApiUrl + '');
  }
  getProjectByDevID(id:string|number):Observable<any[]>{
    return this.http.get<any>(this.projectApiUrl + `/ProjectByDev/${id}`);
  }

  addProject(data:any){
    return this.http.post(this.projectApiUrl + '/InsertProject', data);
  }

  updateProject(data:any){
    return this.http.post(this.projectApiUrl + '/UpdateProject', data);
  }

  deleteProject(projectID:number|string){
    return this.http.post(this.projectApiUrl + `/DeleteProject/${projectID}`, projectID);
  }
}
