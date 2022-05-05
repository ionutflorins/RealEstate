import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ClientApiService {

readonly clientApiUrl = "https://localhost:7136/api/Client";

  constructor(private http:HttpClient) { }

  getClientList():Observable<any[]>{
    return this.http.get<any>(this.clientApiUrl + '');
  }

  addClient(data:any){
    return this.http.post(this.clientApiUrl + '/InsertClient', data);
  }

  updateClient(data:any){
    return this.http.post(this.clientApiUrl + '/UpdateClient', data);
  }

  deleteClient(clientID:number|string){
    return this.http.post(this.clientApiUrl + `/DeleteClient/${clientID}`, clientID);
  }

}
