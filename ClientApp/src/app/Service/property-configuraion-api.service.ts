import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class PropertyConfiguraionApiService {

  readonly propertyConfigurationApiUrl = "https://localhost:7136/api/PropertyConfiguration";

  constructor(private http:HttpClient) { }

  getPropertyConfigurationList():Observable<any[]>{
    return this.http.get<any>(this.propertyConfigurationApiUrl + '');
  }

  addPropertyConfiguration(data:any){
    return this.http.post(this.propertyConfigurationApiUrl + '/InsertPropertyConfiguration', data);
  }

  updatePropertyConfiguration(data:any){
    return this.http.post(this.propertyConfigurationApiUrl + '/UpdatePropertyConfiguration', data);
  }

  deletePropertyConfiguration(propertyConfigurationID:number|string){
    return this.http.post(this.propertyConfigurationApiUrl + `/DeletePropertyConfiguration'/${propertyConfigurationID}`, propertyConfigurationID);
  }

}
