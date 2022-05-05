import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PropertyConfigurationItemsApiService {

  readonly propertyConfigurationItemsApiUrl = "https://localhost:7136/api/PropertyConfigurationItems";

  constructor(private http:HttpClient) { }

  getPropertyConfigurationItemsList():Observable<any[]>{
    return this.http.get<any>(this.propertyConfigurationItemsApiUrl + '');
  }

  addPropertyConfigurationItems(data:any){
    return this.http.post(this.propertyConfigurationItemsApiUrl + '/InsertPropertyConfigurationItems', data);
  }

  updatePropertyConfigurationItems(data:any){
    return this.http.post(this.propertyConfigurationItemsApiUrl + '/UpdatePropertyConfigurationItems', data);
  }

  deletePropertyConfigurationItems(propertyConfigurationItemsID:number|string){
    return this.http.post(this.propertyConfigurationItemsApiUrl + `/DeletePropertyConfigurationItems/${propertyConfigurationItemsID}`, propertyConfigurationItemsID);
  }

}
