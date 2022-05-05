import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class ConfigurationOptionApiService {

  readonly configurationOptionApiUrl = "https://localhost:7136/api/ConfigurationOption";

  constructor(private http:HttpClient) { }

  getConfigurationOptionList():Observable<any[]>{
    return this.http.get<any>(this.configurationOptionApiUrl + '');
  }

  addConfigurationOption(data:any){
    return this.http.post(this.configurationOptionApiUrl + '/InsertConfigurationOption', data);
  }

  updateConfigurationOption(data:any){
    return this.http.post(this.configurationOptionApiUrl + '/UpdateConfigurationOption', data);
  }

  deleteConfigurationOption(configurationOptionID:number|string){
    return this.http.post(this.configurationOptionApiUrl + `/DeleteConfigurationOption/${configurationOptionID}`, configurationOptionID);
  }

}
