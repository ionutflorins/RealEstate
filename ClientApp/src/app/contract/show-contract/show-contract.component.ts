import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ContractApiService } from 'src/app/Service/contract-api.service';
@Component({
  selector: 'app-show-contract',
  templateUrl: './show-contract.component.html',
  styleUrls: ['./show-contract.component.css']
})
export class ShowContractComponent implements OnInit {

  contractList$!: Observable<any[]>
  constructor(private contractService : ContractApiService) { }

  ngOnInit(): void {
    this.contractList$ = this.contractService.getContractList();
  }

    //Variables(properties)
    contractModalTitle: string = "";
    activateAddEditContractComponent: boolean = false;
    contract: any;

    clientModalAdd(){
      this.contract = {
        id:0,
        contractNumber:null,
        date:null,
        clientID:0,
        developerID:0,
        propertyID:0
      }
      this.contractModalTitle = "Add Client";
      this.activateAddEditContractComponent = true;

  }

  contractModalEdit(contractItem : any){
    this.contract = contractItem;
    this.contractModalTitle = "Edit Client"
    this.activateAddEditContractComponent = true;
  }

  deleteContract(contractItem : any){
    if (confirm(`Are you sure you want to delete contract ${contractItem.contractNumber}?`)) {
      this.contractService.deleteContract(contractItem.id).subscribe(res => {
        var closeModalBtn = document.getElementById('add-edit-contract-modal-close');
        if (closeModalBtn) {
          closeModalBtn.click();
        }

        var showDeleteSucces = document.getElementById('delete-succes-alert');
        if (showDeleteSucces) {
          showDeleteSucces.style.display = "block";
        }

        setTimeout(function () {
          if (showDeleteSucces) {
            showDeleteSucces.style.display = "none"
          }
        }, 4000);
        this.contractList$= this.contractService.getContractList();

      })
    }

  }

  contractModalClose(){
    this.activateAddEditContractComponent = false;
    this.contractList$ = this.contractService.getContractList();
  }

}
