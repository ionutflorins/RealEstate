import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ConfigurationOptionApiService } from 'src/app/Service/configuration-option-api.service';
import { PropertyConfigurationItemsApiService } from 'src/app/Service/property-configuration-items-api.service';
import { filter, map } from 'rxjs/operators';
import { ConfigurationItemApiService } from 'src/app/Service/configuration-item-api.service';


@Component({
  selector: 'app-add-edit-propertyconfigurationitems',
  templateUrl: './add-edit-propertyconfigurationitems.component.html',
  styleUrls: ['./add-edit-propertyconfigurationitems.component.css']
})
export class AddEditPropertyconfigurationitemsComponent implements OnInit {

  propertyConfigurationItemsList$!: Observable<any[]>;
  configurationItemsList$!: Observable<any[]>;
  configurationOptionsList$!: Observable<any[]>;

  constructor(private propertyConfigurationItemsService: PropertyConfigurationItemsApiService,
    private configOptionService: ConfigurationOptionApiService,
    private configItemService: ConfigurationItemApiService) { }

  @Input() propertyConfigItem: any;
  propertyConfigItemID: number = 0;
  propertyConfigItemPropertyConfigID: number = 0;
  propertyConfigItemConfigItemID: number = 0;
  propertyConfigOptionID: number = 0;

  ngOnInit(): void {
    this.configurationItemsList$ = this.configItemService.getconfigurationItemList();
    this.propertyConfigItemID = this.propertyConfigItem.id;
    this.propertyConfigItemPropertyConfigID = this.propertyConfigItem.propertyConfigurationID;
    this.propertyConfigItemConfigItemID = this.propertyConfigItem.configurationItemID;
    this.propertyConfigOptionID = this.propertyConfigItem.configurationOptionID;
  }

    //variables
    descriptionConfigItems: any;
    descriptionConfigOptions: any;

    onDisplayCategory() {
      this.configurationOptionsList$ = this.configOptionService
        .getConfigurationOptionList().pipe(map(r => r.filter(x => {
          return x.configurationItemId === this.descriptionConfigItems
        })))
    }


  addClientPropertyConfigItem() {
    var propertyConfigItem = {
      propertyConfigurationID: this.propertyConfigItemPropertyConfigID,
      configurationItemID: this.descriptionConfigOptions,
      configurationOptionID: this.propertyConfigOptionID
    }
    this.propertyConfigurationItemsService.addPropertyConfigurationItems(propertyConfigItem).subscribe(res => {
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

  updateClientPropertyConfigItem() {
    var propertyConfigItem = {
      id: this.propertyConfigItemID,
      propertyConfigurationID: this.propertyConfigItemPropertyConfigID,
      configurationItemID: this.propertyConfigItemConfigItemID,
      configurationOptionID: this.propertyConfigOptionID
    }
    var id: number = this.propertyConfigItemID;
    this.propertyConfigurationItemsService.addPropertyConfigurationItems(propertyConfigItem).subscribe(res => {
      var closeModalBtn = document.getElementById('update-edit-modal-close');
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
