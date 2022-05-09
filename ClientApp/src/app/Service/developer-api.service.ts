import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DeveloperApiService {

  readonly developerApiUrl = "https://localhost:7136/api/Developer";

  constructor(private http:HttpClient) { }

  getDeveloperList():Observable<any[]>{
    return this.http.get<any>(this.developerApiUrl + '');
  }

  addDeveloper(data:any){
    return this.http.post(this.developerApiUrl + '/InsertDeveloper', data);
  }

  updateDeveloper(data:any){
    return this.http.post(this.developerApiUrl + `/UpdateDeveloper`, data);
  }

  deleteDeveloper(developerID:number|string){
    return this.http.post(this.developerApiUrl + `/DeleteDeveloper/${developerID}`, developerID);
  }

}
