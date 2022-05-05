import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ConfigurationOptionApiService } from 'src/app/Service/configuration-option-api.service';

@Component({
  selector: 'app-show-configurationoption',
  templateUrl: './show-configurationoption.component.html',
  styleUrls: ['./show-configurationoption.component.css']
})
export class ShowConfigurationoptionComponent implements OnInit {

  configurationOptionList$! : Observable<any[]>

  constructor(private configurationOptionService : ConfigurationOptionApiService) { }

  ngOnInit(): void {
    this.configurationOptionList$ = this.configurationOptionService.getConfigurationOptionList();
  }

}
