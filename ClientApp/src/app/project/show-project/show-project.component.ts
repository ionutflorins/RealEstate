import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { ProjectApiService } from 'src/app/Service/project-api.service';

@Component({
  selector: 'app-show-project',
  templateUrl: './show-project.component.html',
  styleUrls: ['./show-project.component.css']
})
export class ShowProjectComponent implements OnInit {

  projectList$!: Observable<any[]>;
  projectId!: number | string;

  constructor(private projectService: ProjectApiService,
    private activatedRoute: ActivatedRoute,
    private router: Router) {
    console.log(this.router.getCurrentNavigation()!.extras.state);
    this.projectId = this.router.getCurrentNavigation()?.extras.state?.id;
  }

  ngOnInit(): void {
    if (this.projectId) {
      this.projectList$ = this.projectService.getProjectByDevID(this.projectId);
    } else
      this.projectList$ = this.projectService.getProjectList();
  }

  @Input() devloperId: any
  //Variables(proprietes)
  
  addEditProjectModalTitle: string = " ";
  activateAddEditProjectComponent: boolean = false;
  project: any;

  modalAdd() {
    this.project = {
      id: 0,
      projectName: null,
      city: null,
      address: null,
      buildingsNo: 3,
      apartmentNo: 300,
      houseNo: 0,
      description: null,
      developerID: this.projectId
    }
    this.addEditProjectModalTitle = "Add Project";
    this.activateAddEditProjectComponent = true;
  }

  modalEdit(projectItem: any) {
    this.project = projectItem;
    this.addEditProjectModalTitle = "Edit Project"
    this.activateAddEditProjectComponent = true;
  }

  deleteProject(projectItem: any) {
    if (confirm(`Are you sure you want to delete ${projectItem.projectName}?`)) {
      this.projectService.deleteProject(projectItem.id).subscribe(res => {
        var closeModalBtn = document.getElementById('add-edit-project-modal-close');
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

        this.projectList$ = this.projectService.getProjectByDevID(this.projectId);
      })
    }
  }

  projectModalClose() {
    this.activateAddEditProjectComponent = false;
    this.projectList$ = this.projectService.getProjectByDevID(this.projectId);
  }

  showProperties(id: number | string) {
    this.router.navigateByUrl('Property-List', {
      state: {
        id
      }
    });
  }
}