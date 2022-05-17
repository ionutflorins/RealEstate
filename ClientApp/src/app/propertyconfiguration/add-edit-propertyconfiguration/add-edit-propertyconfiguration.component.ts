import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { PropertyConfiguraionApiService } from 'src/app/Service/property-configuraion-api.service';

@Component({
  selector: 'app-add-edit-propertyconfiguration',
  templateUrl: './add-edit-propertyconfiguration.component.html',
  styleUrls: ['./add-edit-propertyconfiguration.component.css']
})
export class AddEditPropertyconfigurationComponent implements OnInit {

  propertyConfigurationList$!: Observable<any[]>;

  constructor(private propertyConfigurationService: PropertyConfiguraionApiService) { }

  @Input() propertyConfiguration: any;
  propertyConfigurationID: number = 0;
  propertyConfigurationFormNumber: string = "";
  propertyConfigurationContractID: number = 0;

  ngOnInit(): void {
    this.propertyConfigurationID = this.propertyConfiguration.id;
    this.propertyConfigurationFormNumber = this.propertyConfiguration.formNumber;
    this.propertyConfigurationContractID = this.propertyConfiguration.contractID;
  }

  addPropertyConfiguration() {
    var propertyConfiguration = {
      formNumber: this.propertyConfigurationFormNumber,
      contractID: this.propertyConfigurationContractID
    }
    this.propertyConfigurationService.addPropertyConfiguration(propertyConfiguration).subscribe(res => {
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


  updatePropertyConfiguration() {
    var propertyConfiguration = {
      id: this.propertyConfigurationID,
      formNumber: this.propertyConfigurationFormNumber,
      contractID: this.propertyConfigurationContractID
    }
    var id: number = this.propertyConfigurationID;
    this.propertyConfigurationService.updatePropertyConfiguration(propertyConfiguration).subscribe(res => {
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

}
