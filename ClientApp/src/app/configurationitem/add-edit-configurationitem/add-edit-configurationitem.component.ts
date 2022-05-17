import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ConfigurationItemApiService } from 'src/app/Service/configuration-item-api.service';

@Component({
  selector: 'app-add-edit-configurationitem',
  templateUrl: './add-edit-configurationitem.component.html',
  styleUrls: ['./add-edit-configurationitem.component.css']
})
export class AddEditConfigurationitemComponent implements OnInit {

  configurationItem$!: Observable<any[]>;

  constructor(private configurationItemService: ConfigurationItemApiService) { }

  @Input() configurationItem: any;
  configurationItemID: number = 0;
  configurationItemDescription: string = "";

  ngOnInit(): void {
    this.configurationItemID = this.configurationItem.id;
    this.configurationItemDescription = this.configurationItem.description
  }

  addConfigurationItem() {
    var configurationItem = {
      description: this.configurationItemDescription
    }
    this.configurationItemService.addConfigurationItem(configurationItem).subscribe(res => {
      var closeModalBtn = document.getElementById('add-modal-close');
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

  updateConfigurationItem() {
    var configurationItem = {
      id: this.configurationItemID,
      description: this.configurationItemDescription
    }
    var id: number = this.configurationItemID;
    this.configurationItemService.updateConfigurationItem(configurationItem).subscribe(res => {
      var closeModalBtn = document.getElementById('add-modal-close');
      if (closeModalBtn) {
        closeModalBtn.click();
      }

      var showAddSucces = document.getElementById('update-succes-alert');
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
