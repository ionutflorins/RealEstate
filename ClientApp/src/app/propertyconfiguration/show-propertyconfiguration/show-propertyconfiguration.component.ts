import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { PropertyConfiguraionApiService } from 'src/app/Service/property-configuraion-api.service';

@Component({
  selector: 'app-show-propertyconfiguration',
  templateUrl: './show-propertyconfiguration.component.html',
  styleUrls: ['./show-propertyconfiguration.component.css']
})
export class ShowPropertyconfigurationComponent implements OnInit {

  propertyConfigurationList$!: Observable<any[]>;
  contractId!:number|string;


  constructor(private propertyConfigurationService: PropertyConfiguraionApiService, 
    private router: Router) {
      console.log(this.router.getCurrentNavigation()!.extras.state);
      this.contractId = this.router.getCurrentNavigation()?.extras.state?.contractId;
     }

  ngOnInit(): void {
    if(this.contractId)
    {
      this.propertyConfigurationList$ = this.propertyConfigurationService.getPropConfigByContrId(this.contractId);
    }else
    this.propertyConfigurationList$ = this.propertyConfigurationService.getPropertyConfigurationList();
  }

  //Variables(properties)
  propertyConfigurationModalTitle: string = "";
  activateAddEditpropertyConfigurationComponent: boolean = false;
  propertyConfiguration: any;

  modalAdd() {
    this.propertyConfiguration = {
      id: 0,
      formNumber: null,
      developerID: 0
    }
    this.propertyConfigurationModalTitle = "Add Property Configuration";
    this.activateAddEditpropertyConfigurationComponent = true;
  }

  modalEdit(propertyConfigurationItem: any) {
    this.propertyConfiguration = propertyConfigurationItem;
    this.propertyConfigurationModalTitle = "Edit Property Configuration"
    this.activateAddEditpropertyConfigurationComponent = true;
  }

  deletePropertyConfiguration(propertyConfigurationtItem: any) {
    if (confirm(`Are you sure you want to delete the form with form number: ${propertyConfigurationtItem.formNumber}?`)) {
      this.propertyConfigurationService.deletePropertyConfiguration(propertyConfigurationtItem.id).subscribe(res => {
        var closeModalBtn = document.getElementById('add-edit-modal-close');
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

        this.propertyConfigurationList$ = this.propertyConfigurationService.getPropertyConfigurationList();
      })
    }
  }

  clientModalClose() {
    this.activateAddEditpropertyConfigurationComponent = false;
    this.propertyConfigurationList$ = this.propertyConfigurationService.getPropertyConfigurationList();
  }

  toPropConfigItem(propConfigId:number|string){
    this.router.navigateByUrl('Propertyconfigurationitems-List', {
      state: {
        propConfigId
      }
    });
  }


}
