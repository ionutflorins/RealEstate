import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { ClientApiService } from 'src/app/Service/client-api.service';


@Component({
  selector: 'app-add-edit-client',
  templateUrl: './add-edit-client.component.html',
  styleUrls: ['./add-edit-client.component.css']
})
export class AddEditClientComponent implements OnInit {

  clientList$!: Observable<any[]>;
  clientId$! : number|string;

  constructor(private clientService: ClientApiService, 
    private activatedRoute: ActivatedRoute) { 
      this.activatedRoute.params.subscribe(params => {
      this.clientId$ = params['id'];
    });}

  @Input() client: any;
  clientID: number = 0;
  clientFirstName: string = "";
  clientLastName: string = "";
  clientPhoneNumber: string = "";
  clientPersonalID: string = "";
  clientSerieNo: string = "";
  clientAddress: string = "";
  clientIssuedBy: string = "";
  clientValidity: string = "";
  clientDeveloperID: number = 0;
  clientAppUserID: string = "";

  ngOnInit(): void {
    this.clientID = this.client.id;
    this.clientFirstName = this.client.firstName;
    this.clientLastName = this.client.lastName;
    this.clientPhoneNumber = this.client.phoneNumber;
    this.clientPersonalID = this.client.personalID;
    this.clientSerieNo = this.client.serieNo;
    this.clientAddress = this.client.address;
    this.clientIssuedBy = this.client.issuedBy;
    this.clientValidity = this.client.validity;
    this.clientDeveloperID = this.client.developerID;
    this.clientAppUserID = this.client.appUserId
  }

  addClient() {
    var client = {
      firstName: this.clientFirstName,
      lastName: this.clientLastName,
      phoneNumber: this.clientPhoneNumber,
      personalID: this.clientPersonalID,
      serieNo: this.clientSerieNo,
      address: this.clientAddress,
      issuedBy: this.clientIssuedBy,
      validity: this.clientValidity,
      developerID: this.clientDeveloperID,
      appUserId:this.clientAppUserID
    }
    this.clientService.addClient(client).subscribe(res => {
      var closeModalBtn = document.getElementById('add-edit-modal-close');
      if (closeModalBtn) {
        closeModalBtn.click();
      }
      var showAddSucces = document.getElementById('add-succes-alert');
      if (showAddSucces) {
        showAddSucces.style.display = "block";
      }
      setTimeout(function () {
        if (showAddSucces) {
          showAddSucces.style.display = "none"
        }
      }, 4000);
    })
  }

  updateClient() {
    var client = {
      id: this.clientID,
      firstName: this.clientFirstName,
      lastName: this.clientLastName,
      phoneNumber: this.clientPhoneNumber,
      personalID: this.clientPersonalID,
      serieNo: this.clientSerieNo,
      address: this.clientAddress,
      issuedBy: this.clientIssuedBy,
      validity: this.clientValidity,
      developerID: this.clientDeveloperID,
      appUserId:this.clientAppUserID
    }
    var id: number = this.clientID
    this.clientService.updateClient(client).subscribe(res => {
      var closeModalBtn = document.getElementById('add-edit-modal-close');
      if (closeModalBtn) {
        closeModalBtn.click();
      }
      var showUpdateSucces = document.getElementById('update-succes-alert');
      if (showUpdateSucces) {
        showUpdateSucces.style.display = "block";
      }
      setTimeout(function () {
        if (showUpdateSucces) {
          showUpdateSucces.style.display = "none"
        }
      }, 4000);
    })

  }
}
