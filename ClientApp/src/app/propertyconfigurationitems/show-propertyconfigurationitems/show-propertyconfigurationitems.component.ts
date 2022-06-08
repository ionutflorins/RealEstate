import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { PropertyConfigurationItemsApiService } from 'src/app/Service/property-configuration-items-api.service';
@Component({
  selector: 'app-show-propertyconfigurationitems',
  templateUrl: './show-propertyconfigurationitems.component.html',
  styleUrls: ['./show-propertyconfigurationitems.component.css']
})
export class ShowPropertyconfigurationitemsComponent implements OnInit {

  propetyConfigurationItemsList$!: Observable<any[]>
  propConfigId!:number|string;
  constructor(private propertyConfigurationItemsService: PropertyConfigurationItemsApiService,
    private router: Router) {
      console.log(this.router.getCurrentNavigation()?.extras.state);
    this.propConfigId = this.router.getCurrentNavigation()?.extras.state?.propConfigId;
   }

  ngOnInit(): void {
    if(this.propConfigId)
    {
      this.propetyConfigurationItemsList$ = this.propertyConfigurationItemsService.getPropConfigItmByPropConfig(this.propConfigId);
    }else
    this.propetyConfigurationItemsList$ = this.propertyConfigurationItemsService.getPropertyConfigurationItemsList();
  }
  //Variables(properties)
  propConfigItemsModalTitle: string = "";
  activateAddEditpropConfigItemsComponent: boolean = false;
  propertyConfigItem: any;

  modalAdd() {
    this.propertyConfigItem = {
      id: 0,
      propertyConfigurationID: this.propConfigId,
      configurationItemID: null,
      configurationOptionID: null,
    }
    this.propConfigItemsModalTitle = "Add Configuration item";
    this.activateAddEditpropConfigItemsComponent = true;
  }

  modalEdit(propertyConfigurationItemsItem: any) {
    this.propertyConfigItem = propertyConfigurationItemsItem;
    this.propConfigItemsModalTitle = "Edit Configuration Item"
    this.activateAddEditpropConfigItemsComponent = true;
  }

  deletePropConfigItem(propertyConfigurationItemsItem: any) {
    if (confirm(`Are you sure you want to delete this Item ${propertyConfigurationItemsItem.configurationOptionID}?`)) {
      this.propertyConfigurationItemsService.deletePropertyConfigurationItems(propertyConfigurationItemsItem.id).subscribe(res => {
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

        this.propetyConfigurationItemsList$ = this.propertyConfigurationItemsService.getPropConfigItmByPropConfig(this.propConfigId);
      })
    }
  }

  clientModalClose() {
    this.activateAddEditpropConfigItemsComponent = false;
    this.propetyConfigurationItemsList$ = this.propertyConfigurationItemsService.getPropConfigItmByPropConfig(this.propConfigId);
  }
}
