import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ProjectApiService } from 'src/app/Service/project-api.service';

@Component({
  selector: 'app-add-edit-project',
  templateUrl: './add-edit-project.component.html',
  styleUrls: ['./add-edit-project.component.css']
})
export class AddEditProjectComponent implements OnInit {

  projectList$!: Observable<any[]>;

  constructor(private projectService: ProjectApiService) { }

  @Input() project: any;
  projectID: number = 0;
  projectname: string = "";
  projectCity: string = "";
  projectAddress: string = "";
  projectBuildingsNo: number = 0;
  projectApartmentNo: number = 0;
  projectHouseNo: number = 0;
  projectdescription: string = "";
  projectDeveloperID: number = 0;

  ngOnInit(): void {
    this.projectID = this.project.id;
    this.projectname = this.project.projectName;
    this.projectCity = this.project.city;
    this.projectAddress = this.project.address;
    this.projectBuildingsNo = this.project.buildingsNo;
    this.projectApartmentNo = this.project.apartmentNo;
    this.projectHouseNo = this.project.houseNo;
    this.projectdescription = this.project.description;
    this.projectDeveloperID = this.project.developerID;
  }

  addProject() {
    var project = {
      projectName: this.projectname,
      city: this.projectCity,
      address: this.projectAddress,
      buildingsNo: this.projectBuildingsNo,
      apartmentNo: this.projectApartmentNo,
      houseNo: this.projectHouseNo,
      description: this.projectdescription,
      developerID: this.projectDeveloperID
    }
    this.projectService.addProject(project).subscribe(res => {
      var closeModalBtn = document.getElementById('add-edit-project-modal-close');
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

  updateProject() {
    var project = {
      id: this.projectID,
      projectName: this.projectname,
      city: this.projectCity,
      address: this.projectAddress,
      buildingsNo: this.projectBuildingsNo,
      apartmentNo: this.projectApartmentNo,
      houseNo: this.projectHouseNo,
      description: this.projectdescription,
      developerID: this.projectDeveloperID
    }
    var id: number = this.projectID
    this.projectService.updateProject(project).subscribe(res => {
      var closeModalBtn = document.getElementById('add-edit-project-modal-close');
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
