import { Component, OnInit } from '@angular/core';
import { Observable} from 'rxjs';
import { DeveloperApiService } from 'src/app/Service/developer-api.service';

@Component({
  selector: 'app-show-developer',
  templateUrl: './show-developer.component.html',
  styleUrls: ['./show-developer.component.css']
})
export class ShowDeveloperComponent implements OnInit {

  developerList$!:Observable<any[]>;

  constructor(private developerService : DeveloperApiService) { }

  ngOnInit(): void {
    this.developerList$ = this.developerService.getDeveloperList();
  }

//Variables(proprietes)
addModalTitle:string = " ";
activateAddDeveloperComponent:boolean = false;
developer:any;

modalAdd(){
this.developer = {
  id:0,
  name:null,
  address:null,
  city:null,
  phoneNumber:null,
  email:null,
  zipCode:null
  }
  this.addModalTitle = "Add Developer";
  this.activateAddDeveloperComponent = true;
}

}
