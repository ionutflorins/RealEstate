import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { PropertyApiService } from 'src/app/Service/property-api.service';

@Component({
  selector: 'app-show-property',
  templateUrl: './show-property.component.html',
  styleUrls: ['./show-property.component.css']
})
export class ShowPropertyComponent implements OnInit {

  propertyList$!: Observable<any[]>;

  constructor(private propertyService: PropertyApiService) { }

  ngOnInit(): void {
    this.propertyList$ = this.propertyService.getPropertyList();
  }

  //Variables(properties)
  propertyModalTitle: string = "";
  activateAddEditPropertyComponent: boolean = false;
  property: any;

  propretyModalAdd() {
    this.property = {
      id: 0,
      type: null,
      price: null,
      roomNo: null,
      identityNo: null,
      buildingNo: null,
      propertySqm: null,
      lotSqm: null,
      description: null,
      projectID: 0
    }
    this.propertyModalTitle = "Add Property";
    this.activateAddEditPropertyComponent = true;
  }

  propertyModalEdit(propertyItem: any) {
    this.property = propertyItem;
    this.propertyModalTitle = "Edit Property"
    this.activateAddEditPropertyComponent = true;
  }

  deleteProperty(propertyItem: any) {
    if (confirm(`Are you sure you want to delete property with Identity Number: ${propertyItem.identityNo}`)) {
      this.propertyService.deleteProperty(propertyItem.id).subscribe(res => {
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
         this.propertyList$ = this.propertyService.getPropertyList();
      })
    }
  }

  propertyModalClose() {
    this.activateAddEditPropertyComponent = false;
    this.propertyList$ = this.propertyService.getPropertyList();
  }
}
