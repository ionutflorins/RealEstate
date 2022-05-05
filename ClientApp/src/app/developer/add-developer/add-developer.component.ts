import { Component, Input ,OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { DeveloperApiService } from 'src/app/Service/developer-api.service';

@Component({
  selector: 'app-add-developer',
  templateUrl: './add-developer.component.html',
  styleUrls: ['./add-developer.component.css']
})
export class AddDeveloperComponent implements OnInit {

  developerList$!:Observable<any[]>;
  
  constructor(private developerService : DeveloperApiService) { }

  @Input() developer:any;
  id : number=0;
  developerName : string = "";
  developerAddress : string ="";
  developerCity : string = "";
  developerPhoneNumber : string = "";
  developerEmail : string = "";
  developerZipCode : string = "";

  ngOnInit(): void {
    // this.developerName= this.developer.Name;
    // this.developerAddress = this.developer.address;
    // this.developerCity = this.developer.city;
    // this.developerPhoneNumber = this.developer.phoneNumber;
    // this.developerEmail = this.developer.email;
    // this.developerZipCode = this.developer.zipCode;
  }
  addDeveloper(){

  }
}
