import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { PropertyConfigurationItemsApiService } from 'src/app/Service/property-configuration-items-api.service';
@Component({
  selector: 'app-show-propertyconfigurationitems',
  templateUrl: './show-propertyconfigurationitems.component.html',
  styleUrls: ['./show-propertyconfigurationitems.component.css']
})
export class ShowPropertyconfigurationitemsComponent implements OnInit {

  propetyConfigurationItemsList$! : Observable<any[]>
  constructor(private propertyConfigurationItemsService : PropertyConfigurationItemsApiService) { }

  ngOnInit(): void {
    this.propetyConfigurationItemsList$ = this.propertyConfigurationItemsService.getPropertyConfigurationItemsList();
  }

}
