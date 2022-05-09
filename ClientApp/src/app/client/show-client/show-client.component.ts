import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ClientApiService } from 'src/app/Service/client-api.service';

@Component({
  selector: 'app-show-client',
  templateUrl: './show-client.component.html',
  styleUrls: ['./show-client.component.css']
})
export class ShowClientComponent implements OnInit {

  clientList$!:Observable<any[]>;

  constructor(private clientService : ClientApiService) { }

  ngOnInit(): void {
    this.clientList$ = this.clientService.getClientList();
  }

  //Variables(properties)
clientModalTitle:string ="";
activateAddEditClientComponent:boolean = false;
client:any;

modalAdd(){
  this.client= {
  id:0,
  firstName:null,
  lastName:null,
  phoneNumber:null,
  personalID:null,
  serieNo:null,
  address:null,
  issuedBy:null,
  validity:null,
  developerID:0
  }
  this.clientModalTitle="Add Client";
  this.activateAddEditClientComponent = true;
}

modalClose(){
  this.activateAddEditClientComponent = false;
  this.clientList$ = this.clientService.getClientList();
}

}
