import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../Service/user.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit{

  userDetails;

  constructor(private router : Router ,private userService : UserService ) {
  }

  ngOnInit(): void {
    this.userService.getUserProfile().subscribe(
      res =>{
        this.userDetails = res;
      },
      err=>{
        console.log(err);
      }
    )
  }
}
