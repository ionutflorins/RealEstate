import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ConfigurationItemApiService } from 'src/app/Service/configuration-item-api.service';
import { ConfigurationOptionApiService } from 'src/app/Service/configuration-option-api.service';

@Component({
  selector: 'app-show-configurationoption',
  templateUrl: './show-configurationoption.component.html',
  styleUrls: ['./show-configurationoption.component.css']
})
export class ShowConfigurationoptionComponent implements OnInit {

  configurationOptionList$! : Observable<any[]>
  configurationItemList$!: Observable<any[]>
  configurationItemList: any=[];

  configurationTypesMap:Map<number, string> = new Map();

  constructor(private configurationOptionService : ConfigurationOptionApiService,
    private configItemListService: ConfigurationItemApiService) { }

  ngOnInit(): void {
    this.configurationOptionList$ = this.configurationOptionService.getConfigurationOptionList();
    this.configurationItemList$=this.configItemListService.getconfigurationItemList();
    this.refreshConfigurationItemMap();
  }
  
  refreshConfigurationItemMap(){
    this.configItemListService.getconfigurationItemList().subscribe(data => {
      this.configurationItemList = data;

      for(let i = 0; i< data.length; i++)
      {
        this.configurationTypesMap.set(this.configurationItemList[i].id, this.configurationItemList[i].description);
      }

    })
  }

}
