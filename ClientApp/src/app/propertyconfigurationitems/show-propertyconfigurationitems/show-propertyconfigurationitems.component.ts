import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { PropertyConfigurationItemsApiService } from 'src/app/Service/property-configuration-items-api.service';
import jspdf from 'jspdf';
import html2canvas from 'html2canvas';
import { ConfigurationItemApiService } from 'src/app/Service/configuration-item-api.service';
import { ConfigurationOptionApiService } from 'src/app/Service/configuration-option-api.service';


@Component({
  selector: 'app-show-propertyconfigurationitems',
  templateUrl: './show-propertyconfigurationitems.component.html',
  styleUrls: ['./show-propertyconfigurationitems.component.css']
})
export class ShowPropertyconfigurationitemsComponent implements OnInit {

  propetyConfigurationItemsList$!: Observable<any[]>
  configurationItemList$!: Observable<any[]>
  propConfigId!: number | string;

  configurationItemList: any = [];
  configurationItemsTypesMap: Map<number, string> = new Map();

  configOptionList:any = [];
  configOptionMap:Map<number, string> = new Map();

  constructor(private propertyConfigurationItemsService: PropertyConfigurationItemsApiService,
    private configItemListService: ConfigurationItemApiService,
    private configOptionService: ConfigurationOptionApiService,
    private router: Router) {
    console.log(this.router.getCurrentNavigation()?.extras.state);
    this.propConfigId = this.router.getCurrentNavigation()?.extras.state?.propConfigId;
  }

  ngOnInit(): void {
    

    if (this.propConfigId) {
      this.propetyConfigurationItemsList$ = this.propertyConfigurationItemsService.getPropConfigItmByPropConfig(this.propConfigId);
    } else
      this.propetyConfigurationItemsList$ = this.propertyConfigurationItemsService.getPropertyConfigurationItemsList();

    this.configurationItemList$ = this.configItemListService.getconfigurationItemList();
    this.refreshConfigurationItemMap();
    this.refreshConfigOptionMap();

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

        if (this.propConfigId) {
          this.propetyConfigurationItemsList$ = this.propertyConfigurationItemsService.getPropConfigItmByPropConfig(this.propConfigId);
        } else
          this.propetyConfigurationItemsList$ = this.propertyConfigurationItemsService.getPropertyConfigurationItemsList();
      })
    }
  }

  clientModalClose() {
    this.activateAddEditpropConfigItemsComponent = false;
    if (this.propConfigId) {
      this.propetyConfigurationItemsList$ = this.propertyConfigurationItemsService.getPropConfigItmByPropConfig(this.propConfigId);
    } else
      this.propetyConfigurationItemsList$ = this.propertyConfigurationItemsService.getPropertyConfigurationItemsList();
  }


  refreshConfigOptionMap(){
    this.configOptionService.getConfigurationOptionList().subscribe(data => {
      this.configOptionList = data;
      for(let i = 0; i < data.length; i++){
        this.configOptionMap.set(this.configOptionList[i].id, this.configOptionList[i].description)
      }
    })
  }

  refreshConfigurationItemMap() {
    this.configItemListService.getconfigurationItemList().subscribe(data => {
      this.configurationItemList = data;
      for (let i = 0; i < data.length; i++) {
        this.configurationItemsTypesMap.set(this.configurationItemList[i].id, this.configurationItemList[i].description);
      }
    })
  }

  exportPdf() {
    var data = document.getElementById('contentToConvert')!;
    html2canvas(data).then(canvas => {
      // Few necessary setting options  
      var imgWidth = 208;
      var pageHeight = 295;
      var imgHeight = canvas.height * imgWidth / canvas.width;
      var heightLeft = imgHeight;

      const contentDataURL = canvas.toDataURL('image/png')
      let pdf = new jspdf('p', 'mm', 'a4'); // A4 size page of PDF  
      var position = 0;
      pdf.addImage(contentDataURL, 'PNG', 0, position, imgWidth, imgHeight)
      pdf.save('MYPdf.pdf'); // Generated PDF   
    });
  }
}
