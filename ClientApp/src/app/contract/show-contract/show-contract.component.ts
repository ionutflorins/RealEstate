import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { ContractApiService } from 'src/app/Service/contract-api.service';
@Component({
  selector: 'app-show-contract',
  templateUrl: './show-contract.component.html',
  styleUrls: ['./show-contract.component.css']
})
export class ShowContractComponent implements OnInit {

  contractList$!: Observable<any[]>
  propertyID!: number | string;
  clientID!: number | string;
  constructor(private contractService: ContractApiService,
    private router: Router) {
    console.log(this.router.getCurrentNavigation()!.extras.state);
    this.propertyID = this.router.getCurrentNavigation()?.extras.state?.id;
    this.clientID = this.router.getCurrentNavigation()?.extras.state?.clientID;
  }

  ngOnInit(): void {
    if (this.propertyID) {
      this.contractList$ = this.contractService.getContractByProp(this.propertyID);
    } else if (this.clientID) {
      this.contractList$ = this.contractService.getContractByProp(this.clientID);
    }
    else
      this.contractList$ = this.contractService.getContractList();
  }

  //Variables(properties)
  contractModalTitle: string = "";
  activateAddEditContractComponent: boolean = false;
  contract: any;

  clientModalAdd() {
    this.contract = {
      id: 0,
      contractNumber: null,
      date: null,
      clientID: "",
      developerID: "",
      propertyID: this.propertyID
    }
    this.contractModalTitle = "Add contract";
    this.activateAddEditContractComponent = true;

  }

  contractModalEdit(contractItem: any) {
    this.contract = contractItem;
    this.contractModalTitle = "Edit contract"
    this.activateAddEditContractComponent = true;
  }

  deleteContract(contractItem: any) {
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
        if (this.propertyID) {
          this.contractList$ = this.contractService.getContractByProp(this.propertyID);
        } else if (this.clientID) {
          this.contractList$ = this.contractService.getContractByProp(this.clientID);
        }
        else
          this.contractList$ = this.contractService.getContractList();

      })
    }

  }

  contractModalClose() {
    this.activateAddEditContractComponent = false;
    if (this.propertyID) {
      this.contractList$ = this.contractService.getContractByProp(this.propertyID);
    } else if (this.clientID) {
      this.contractList$ = this.contractService.getContractByProp(this.clientID);
    }
    else
      this.contractList$ = this.contractService.getContractList();
  }

  getContract(clientId: number | string) {
    this.router.navigateByUrl('client-form', {
      state: {
        clientId
      }
    });
  }

  showPropConfig(contractId: number | string) {
    this.router.navigateByUrl('PropertyConfiguration-List', {
      state: {
        contractId
      }
    });
  }

}
