import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ContractApiService {

  readonly contractApiUrl = "https://localhost:7136/api/Contract";

  constructor(private http:HttpClient) { }

  getContractList():Observable<any[]>{
    return this.http.get<any>(this.contractApiUrl + '');
  }

  addContract(data:any){
    return this.http.post(this.contractApiUrl + '/Insertcontract', data);
  }

  updateContract(data:any){
    return this.http.post(this.contractApiUrl + '/Updatecontract', data);
  }

  deleteContract(contractID:number|string){
    return this.http.post(this.contractApiUrl + `/Deletecontract/${contractID}`, contractID);
  }
}
