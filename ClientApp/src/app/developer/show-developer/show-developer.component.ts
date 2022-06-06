import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { ClientApiService } from 'src/app/Service/client-api.service';
import { DeveloperApiService } from 'src/app/Service/developer-api.service';
import { ProjectApiService } from 'src/app/Service/project-api.service';


@Component({
  selector: 'app-show-developer',
  templateUrl: './show-developer.component.html',
  styleUrls: ['./show-developer.component.css']
})
export class ShowDeveloperComponent implements OnInit {

  developerList$!: Observable<any[]>;
  clientList$!: Observable<any[]>;
  projectList$!: Observable<any[]>;

  constructor(private developerService: DeveloperApiService,
    private clientService: ClientApiService,
    private projectService: ProjectApiService,
    private router: Router,
    private activatedRoute: ActivatedRoute) {
  }

  ngOnInit(): void {
    this.developerList$ = this.developerService.getDeveloperList();
    this.clientList$ = this.clientService.getClientList();
    this.projectList$ = this.projectService.getProjectList();
  }

  //Variables(proprietes)
  addModalTitle: string = " ";
  activateAddDeveloperComponent: boolean = false;
  developer: any;

  modalAdd() {
    this.developer = {
      id: 0,
      name: null,
      address: null,
      city: null,
      phoneNumber: null,
      email: null,
      zipCode: null
    }
    this.addModalTitle = "Add Developer";
    this.activateAddDeveloperComponent = true;
  }

  modalEdit(developerItem: any) {
    this.developer = developerItem;
    this.addModalTitle = "Edit Developer"
    this.activateAddDeveloperComponent = true;
  }

  deleteDeveloper(developerItem: any) {
    if (confirm(`Are you sure you want to delete developer${developerItem.name}`)) {
      this.developerService.deleteDeveloper(developerItem.id).subscribe(res => {
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
        this.developerList$ = this.developerService.getDeveloperList();

      })
    }
  }

  modalClose() {
    this.activateAddDeveloperComponent = false;
    this.developerList$ = this.developerService.getDeveloperList();
  }

  showClientID(id: number | string) {
    this.router.navigateByUrl('Client-List', {
      state: {
        id
    }});
  }
  showProjectId(projid: number | string) {
    // console.log(projid);
    // this.router.navigate(['Project-List', projid]);
 
  }
}
