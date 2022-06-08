import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { filter, map } from 'rxjs/operators';


import { ConfigurationItemApiService } from '../Service/configuration-item-api.service';
import { ConfigurationOptionApiService } from '../Service/configuration-option-api.service';

@Component({
  selector: 'app-client-form',
  templateUrl: './client-form.component.html',
  styleUrls: ['./client-form.component.css']
})
export class ClientFormComponent implements OnInit {

  configurationItemsList$!: Observable<any[]>;
  configurationOptionsList$!: Observable<any[]>;
  isValidFormSubmitted = false;
  contractID!: number | string;

  constructor(private configItemService: ConfigurationItemApiService,
    private configOptionService: ConfigurationOptionApiService,
    private formBuilder: FormBuilder,
    private router: Router) {
    this.contractID = this.router.getCurrentNavigation()?.extras.state?.contractId;
  }

  ngOnInit(): void {
    this.configurationItemsList$ = this.configItemService.getconfigurationItemList();
    //this.configurationOptionsList$ = this.configOptionService.getConfigurationOptionList();
  }

  //variables
  descriptionConfigItems: any;
  descriptionConfigOptions: any;

  onDisplayCategory() {
    this.configurationOptionsList$ = this.configOptionService
      .getConfigurationOptionList().pipe(map(r => r.filter(x => {
        return x.configurationItemId === this.descriptionConfigItems
      })))
  }

}
