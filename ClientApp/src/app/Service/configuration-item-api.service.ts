import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class ConfigurationItemApiService {

  readonly configurationItemApiUrl = "https://localhost:7136/api/ConfigurationItem";

  constructor(private http:HttpClient) { }

  getconfigurationItemList():Observable<any[]>{
    return this.http.get<any>(this.configurationItemApiUrl + '');
  }

  addConfigurationItem(data:any){
    return this.http.post(this.configurationItemApiUrl + '/InsertConfigurationItem', data);
  }

  updateConfigurationItem(data:any){
    return this.http.post(this.configurationItemApiUrl + '/UpdateConfigurationItem', data);
  }

  deleteConfigurationItem(configurationItemID:number|string){
    return this.http.post(this.configurationItemApiUrl + `/DeleteConfigurationItem/${configurationItemID}`, configurationItemID);
  }

}
