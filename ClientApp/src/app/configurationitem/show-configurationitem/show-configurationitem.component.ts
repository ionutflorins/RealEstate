import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ConfigurationItemApiService } from 'src/app/Service/configuration-item-api.service';

@Component({
  selector: 'app-show-configurationitem',
  templateUrl: './show-configurationitem.component.html',
  styleUrls: ['./show-configurationitem.component.css']
})
export class ShowConfigurationitemComponent implements OnInit {

  configurationItemList$!: Observable<any[]>
  constructor(private configurationItemService: ConfigurationItemApiService) { }

  ngOnInit(): void {
    this.configurationItemList$ = this.configurationItemService.getconfigurationItemList();
  }

  //Variables(proprietes)
  addModalTitle: string = " ";
  activateAddConfigurationItemComponent: boolean = false;
  configurationItem: any;

  modalAdd() {
    this.configurationItem = {
      id: 0,
      description: null,
    }
    this.addModalTitle = "Add Developer";
    this.activateAddConfigurationItemComponent = true;
  }

  modalEdit(configurationItemItems: any) {
    this.configurationItem = configurationItemItems;
    this.addModalTitle = "Edit Configuration Items"
    this.activateAddConfigurationItemComponent = true;
  }

  deleteConfigurationItem(configurationItemItems: any) {
    if (confirm(`Are you sure you want to delete item ${configurationItemItems.description}`)) {
      this.configurationItemService.deleteConfigurationItem(configurationItemItems.id).subscribe(res => {
        var closeModalBtn = document.getElementById('add-modal-close');
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
        this.configurationItemList$ = this.configurationItemService.getconfigurationItemList();

      })
    }
  }

  modalClose() {
    this.activateAddConfigurationItemComponent = false;
    this.configurationItemList$ = this.configurationItemService.getconfigurationItemList();
  }


}
