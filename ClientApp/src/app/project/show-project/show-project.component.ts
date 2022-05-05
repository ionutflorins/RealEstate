import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ProjectApiService } from 'src/app/Service/project-api.service';

@Component({
  selector: 'app-show-project',
  templateUrl: './show-project.component.html',
  styleUrls: ['./show-project.component.css']
})
export class ShowProjectComponent implements OnInit {

  projectList$! : Observable<any[]>;

  constructor(private projectService : ProjectApiService) { }

  ngOnInit(): void {
    this.projectList$ = this.projectService.getProjectList();
  }
}
