import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PropertyApiService {

  readonly propertyApiUrl = "https://localhost:7136/api/Property";

  constructor(private http:HttpClient) { }

  getPropertyList():Observable<any[]>{
    return this.http.get<any>(this.propertyApiUrl + '');
  }
  
  getPropByProj(id: number|string):Observable<any[]>{
    return this.http.get<any>(this.propertyApiUrl + `/GetPropByProj/${id}`);
  }
  addProperty(data:any){
    return this.http.post(this.propertyApiUrl + '/InsertProperty', data);
  }

  updateProperty(data:any){
    return this.http.post(this.propertyApiUrl + '/UpdateProperty', data);
  }

  deleteProperty(propertyID:number|string){
    return this.http.post(this.propertyApiUrl + `/DeleteProperty/${propertyID}`, propertyID);
  }
}
