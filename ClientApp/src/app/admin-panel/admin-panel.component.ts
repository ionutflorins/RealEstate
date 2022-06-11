import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { DeveloperApiService } from '../Service/developer-api.service';


@Component({

  selector: 'app-admin-panel',
  templateUrl: './admin-panel.component.html',
  styleUrls: ['./admin-panel.component.css']
})
export class AdminPanelComponent implements OnInit {

  developerList$!: Observable<any[]>;
  
  constructor(private developerService: DeveloperApiService) { 
    
  }

  ngOnInit(): void {
    this.developerList$ = this.developerService.getDeveloperList();
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

    modalClose() {
      this.activateAddDeveloperComponent = false;
      this.developerList$ = this.developerService.getDeveloperList();
    }


}
