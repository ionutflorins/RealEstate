import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { DeveloperApiService } from '../Service/developer-api.service';
import { UserService } from '../Service/user.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit{

  developerList$!: Observable<any[]>;
  userDetails;

  constructor(private router : Router ,private userService : UserService,
    private devServ: DeveloperApiService ) {
  }

  ngOnInit(): void {
    this.developerList$ = this.devServ.getDeveloperList();
    this.userService.getUserProfile().subscribe(
      res =>{
        this.userDetails = res;
      },
      err=>{
        console.log(err);
      }
    )
  }
  showProjectId(id: number | string) {
    this.router.navigateByUrl('Project-List', {
      state: {
        id
      }
    });
  }
  
  showClientID(id: number | string) {
    this.router.navigateByUrl('Client-List', {
      state: {
        id
      }
    });
  }
}
