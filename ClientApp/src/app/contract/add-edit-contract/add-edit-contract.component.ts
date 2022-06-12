import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, observable } from 'rxjs';
import { ContractApiService } from 'src/app/Service/contract-api.service';

@Component({
  selector: 'app-add-edit-contract',
  templateUrl: './add-edit-contract.component.html',
  styleUrls: ['./add-edit-contract.component.css']
})
export class AddEditContractComponent implements OnInit {

  contract$!: Observable<any[]>;
  constructor(private contractService: ContractApiService,
    private router: Router) {
   }

  @Input() contract: any;
  contractID: number = 0;
  contractnumber: string = "";
  contractDate: string = "";
  contractClientID: number = 0;
  contractDeveloperID: number = 0;
  contractPropertyID: number = 0;

  ngOnInit(): void {
    this.contractID = this.contract.id;
    this.contractnumber = this.contract.contractNumber;
    this.contractDate = this.contract.date;
    this.contractClientID=this.contract.clientID;
    this.contractDeveloperID=this.contract.developerID;
    this.contractPropertyID = this.contract.propertyID;
  }


  addContract(){
    var contract = {
      contractNumber: this.contractnumber,
      date: this.contractDate,
      clientID: this.contractClientID,
      developerID: this.contractDeveloperID,
      propertyID: this.contractPropertyID,
    }
    this.contractService.addContract(contract).subscribe(res => {
      var closeModalBtn = document.getElementById('add-edit-contract-modal-close');
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

  updateContract(){
    var contract = {
      id:this.contract.contractID,
      contractNumber: this.contractnumber,
      date: this.contractDate,
      clientID: this.contractClientID,
      developerID: this.contractDeveloperID,
      propertyID: this.contractPropertyID,
    }
    var id:number = this.contractID;
    this.contractService.updateContract(contract).subscribe(res => {
      var closeModalBtn = document.getElementById('add-edit-contract-modal-close');
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


}
