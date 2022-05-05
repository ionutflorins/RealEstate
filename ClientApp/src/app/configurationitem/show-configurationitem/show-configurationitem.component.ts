import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ConfigurationItemApiService } from 'src/app/Service/configuration-item-api.service';
@Component({
  selector: 'app-show-configurationitem',
  templateUrl: './show-configurationitem.component.html',
  styleUrls: ['./show-configurationitem.component.css']
})
export class ShowConfigurationitemComponent implements OnInit {

  configurationItemList$! : Observable<any[]>
  constructor(private configurationItemService : ConfigurationItemApiService) { }

  ngOnInit(): void {
    this.configurationItemList$ = this.configurationItemService.getconfigurationItemList();
  }

}
