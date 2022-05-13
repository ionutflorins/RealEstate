import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { PropertyApiService } from 'src/app/Service/property-api.service';

@Component({
  selector: 'app-add-edit-property',
  templateUrl: './add-edit-property.component.html',
  styleUrls: ['./add-edit-property.component.css']
})
export class AddEditPropertyComponent implements OnInit {

  propertyList$!: Observable<any[]>;

  constructor(private propertyService: PropertyApiService) { }

  @Input() property: any;
  propertyID: number = 0;
  propertyType: string = "";
  propertyPrice: number = 0;
  propertyRoomNo: number = 0;
  propertyIdentityNo: string = "";
  propertyBuildingNo : string ="";
  propertySquareM : string = "";
  propertyLotSquareM : string = "";
  propertyDescription : string = "";
  propertyProjectID : number = 0;

  ngOnInit(): void {
    this.propertyID = this.property.id;
    this.propertyType = this.property.type;
    this.propertyPrice = this.property.price;
    this.propertyRoomNo = this.property.roomNo;
    this.propertyIdentityNo = this.property.identityNo;
    this.propertyBuildingNo = this.property.buildingNo;
    this.propertySquareM = this.property.propertySqm;
    this.propertyLotSquareM = this.property.lotSqm;
    this.propertyDescription = this.property.description;
    this.propertyProjectID = this.property.projectID;
  }


  addProperty(){
    var property = {
      type: this.propertyType,
      price: this.propertyPrice,
      roomNo: this.propertyRoomNo,
      identityNo: this.propertyIdentityNo,
      buildingNo: this.propertyBuildingNo,
      propertySqm: this.propertySquareM,
      lotSqm: this.propertyLotSquareM,
      description: this.propertyDescription,
      projectID: this.propertyProjectID
    }
    this.propertyService.addProperty(property).subscribe(res => {
      var closeModalBtn = document.getElementById('add-edit-property-modal-close');
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

  updateProperty(){
    var property = {
      id:this.propertyID,
      type: this.propertyType,
      price: this.propertyPrice,
      roomNo: this.propertyRoomNo,
      identityNo: this.propertyIdentityNo,
      buildingNo: this.propertyBuildingNo,
      propertySqm: this.propertySquareM,
      lotSqm: this.propertyLotSquareM,
      description: this.propertyDescription,
      projectID: this.propertyProjectID
    }
    var id:number = this.propertyID
    this.propertyService.updateProperty(property).subscribe(res => {
      var closeModalBtn = document.getElementById('add-edit-property-modal-close');
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
