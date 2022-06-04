import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, ReactiveFormsModule  } from '@angular/forms';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';

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


  constructor(private configItemService: ConfigurationItemApiService,
    private configOptionService: ConfigurationOptionApiService,
    private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.configurationItemsList$ = this.configItemService.getconfigurationItemList();
    this.configurationOptionsList$ = this.configOptionService.getConfigurationOptionList();
  }

  //variables
  descriptionConfigItems: any;
  configurationItem: any;
  descriptionConfigOptions: any;
  configurationOption: any
  currentChoiceList$!: string[];
  showConfigItems() {
    this.configurationItem = {
      configItemID: this.configurationItem.id,
      descriptionConfigItems: this.configurationItem.description,
    };
  }

  showConfigOptions() {
    this.configurationOption = {
      configOptionsID: this.configurationOption.id,
      descriptionConfigOptions: this.configurationOption.description,
      configOptItemsID: this.configurationOption.configurationItemId
    }
  }

  onDisplayCategory() {
    console.log("change works");
    console.log(this.descriptionConfigItems)
  }
}
