import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { PropertyConfiguraionApiService } from 'src/app/Service/property-configuraion-api.service';
@Component({
  selector: 'app-show-propertyconfiguration',
  templateUrl: './show-propertyconfiguration.component.html',
  styleUrls: ['./show-propertyconfiguration.component.css']
})
export class ShowPropertyconfigurationComponent implements OnInit {

  propertyConfigurationList$! : Observable<any[]>;
  constructor(private propertyConfigurationService : PropertyConfiguraionApiService) { }

  ngOnInit(): void {
    this.propertyConfigurationList$ = this.propertyConfigurationService.getPropertyConfigurationList();
  }

}
