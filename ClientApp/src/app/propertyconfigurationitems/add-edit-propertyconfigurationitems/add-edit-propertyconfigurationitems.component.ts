import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { PropertyConfigurationItemsApiService } from 'src/app/Service/property-configuration-items-api.service';

@Component({
  selector: 'app-add-edit-propertyconfigurationitems',
  templateUrl: './add-edit-propertyconfigurationitems.component.html',
  styleUrls: ['./add-edit-propertyconfigurationitems.component.css']
})
export class AddEditPropertyconfigurationitemsComponent implements OnInit {

  propertyConfigurationItemsList$!: Observable<any[]>;

  constructor(private propertyConfigurationItemsService: PropertyConfigurationItemsApiService) { }

  @Input() propertyConfigItem: any;
  propertyConfigItemID: number = 0;
  propertyConfigItemPropertyConfigID: number = 0;
  propertyConfigItemConfigItemID: number = 0;
  propertyConfigOptionID: number = 0;

  ngOnInit(): void {
    this.propertyConfigItemID = this.propertyConfigItem.id;
    this.propertyConfigItemPropertyConfigID = this.propertyConfigItem.propertyConfigurationID;
    this.propertyConfigItemConfigItemID = this.propertyConfigItem.configurationItemID;
    this.propertyConfigOptionID = this.propertyConfigItem.configurationOptionID;
  }

  addClientPropertyConfigItem() {
    var propertyConfigItem = {
      propertyConfigurationID: this.propertyConfigItemPropertyConfigID,
      configurationItemID: this.propertyConfigItemConfigItemID,
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
