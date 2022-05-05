import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { PropertyApiService } from 'src/app/Service/property-api.service';

@Component({
  selector: 'app-show-property',
  templateUrl: './show-property.component.html',
  styleUrls: ['./show-property.component.css']
})
export class ShowPropertyComponent implements OnInit {

  propertyList$! : Observable<any[]>

  constructor(private propertyService : PropertyApiService) { }

  ngOnInit(): void {
    this.propertyList$ = this.propertyService.getPropertyList();
  }

}
