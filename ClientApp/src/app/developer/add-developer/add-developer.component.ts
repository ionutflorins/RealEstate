import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { DeveloperApiService } from 'src/app/Service/developer-api.service';

@Component({
  selector: 'app-add-developer',
  templateUrl: './add-developer.component.html',
  styleUrls: ['./add-developer.component.css']
})
export class AddDeveloperComponent implements OnInit {

  developerList$!: Observable<any[]>;

  constructor(private developerService: DeveloperApiService) { }

  @Input() developer: any;
  developerID: number = 0;
  developerName: string = "";
  developerAddress: string = "";
  developerCity: string = "";
  developerPhoneNumber: string = "";
  developerEmail: string = "";
  developerZipCode: string = "";

  ngOnInit(): void {
    this.developerID = this.developer.id;
    this.developerName = this.developer.name;
    this.developerAddress = this.developer.address;
    this.developerCity = this.developer.city;
    this.developerPhoneNumber = this.developer.phoneNumber;
    this.developerEmail = this.developer.email;
    this.developerZipCode = this.developer.zipCode;
  }
  addDeveloper() {
    var developer = {
      name: this.developerName,
      address: this.developerAddress,
      city: this.developerCity,
      phoneNumber: this.developerPhoneNumber,
      email: this.developerEmail,
      zipCode: this.developerZipCode
    }
    this.developerService.addDeveloper(developer).subscribe(res => {
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

  updateDeveloper(){
    var developer = {
      id:this.developerID,
      name: this.developerName,
      address: this.developerAddress,
      city: this.developerCity,
      phoneNumber: this.developerPhoneNumber,
      email: this.developerEmail,
      zipCode: this.developerZipCode
    }
    var id:number = this.developerID;
    this.developerService.updateDeveloper(developer).subscribe(res => {
      var closeModalBtn = document.getElementById('add-modal-close');
      if (closeModalBtn) {
        closeModalBtn.click();
      }

      var showUpdateSucces = document.getElementById('update-succes-alert');
      if (showUpdateSucces) {
        showUpdateSucces.style.display = "block";
      }

      setTimeout(function () {
        if (showUpdateSucces) {
          showUpdateSucces.style.display = "none"
        }
      }, 4000);
    })
  }
}
