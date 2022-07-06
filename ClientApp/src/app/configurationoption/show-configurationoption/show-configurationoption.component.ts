import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { ConfigurationItemApiService } from 'src/app/Service/configuration-item-api.service';
import { ConfigurationOptionApiService } from 'src/app/Service/configuration-option-api.service';

@Component({
  selector: 'app-show-configurationoption',
  templateUrl: './show-configurationoption.component.html',
  styleUrls: ['./show-configurationoption.component.css']
})
export class ShowConfigurationoptionComponent implements OnInit {

  configurationOptionList$!: Observable<any[]>
  configurationItemList$!: Observable<any[]>
  configurationItemList: any = [];
  configItemID!: number | string;

  configurationTypesMap: Map<number, string> = new Map();

  constructor(private configurationOptionService: ConfigurationOptionApiService,
    private configItemListService: ConfigurationItemApiService,
    private router: Router) {
    this.configItemID = this.router.getCurrentNavigation()?.extras.state?.configItemId;
  }

  ngOnInit(): void {
    if(this.configItemID)
    this.configurationOptionList$ = this.configurationOptionService.getConfigOptByPropIdList(this.configItemID)
    else
    this.configurationOptionList$ = this.configurationOptionService.getConfigurationOptionList();
    
    this.configurationItemList$ = this.configItemListService.getconfigurationItemList();
    this.refreshConfigurationItemMap();
  }

  //Variables(proprietes)
  addModalTitle: string = " ";
  activateAddConfigOptComponent: boolean = false;
  configOption: any;

  modalAdd() {
    this.configOption = {
      id: 0,
      description: null,
      configurationItemId: this.configItemID,
    }
    this.addModalTitle = "Add Configuration Option";
    this.activateAddConfigOptComponent = true;
  }
  modalEdit(configurationOptionItem: any) {
    this.configOption = configurationOptionItem
    this.addModalTitle = "Edit Configuration Option";
    this.activateAddConfigOptComponent = true;
  }

  modalClose() {
    this.activateAddConfigOptComponent = false;
    if(this.configItemID)
    this.configurationOptionList$ = this.configurationOptionService.getConfigOptByPropIdList(this.configItemID)
    else
    this.configurationOptionList$ = this.configurationOptionService.getConfigurationOptionList();
  }

  deleteConfigOpt(configurationOptionItem: any) {
    if (confirm(`Are you sure you want to delete ${configurationOptionItem.description}`)) {
      this.configurationOptionService.deleteConfigurationOption(configurationOptionItem.id).subscribe(res => {
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
        if(this.configItemID)
    this.configurationOptionList$ = this.configurationOptionService.getConfigOptByPropIdList(this.configItemID)
    else
    this.configurationOptionList$ = this.configurationOptionService.getConfigurationOptionList();
      })
    }
  }

  refreshConfigurationItemMap() {
    this.configItemListService.getconfigurationItemList().subscribe(data => {
      this.configurationItemList = data;
      for (let i = 0; i < data.length; i++) {
        this.configurationTypesMap.set(this.configurationItemList[i].id, this.configurationItemList[i].description);
      }
    })
  }

}
