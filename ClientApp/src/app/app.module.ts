import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { DeveloperComponent } from './developer/developer.component';
import { ShowDeveloperComponent } from './developer/show-developer/show-developer.component';

import { DeveloperApiService } from './Service/developer-api.service';
import { AddDeveloperComponent } from './developer/add-developer/add-developer.component';
import { ClientComponent } from './client/client.component';
import { ShowClientComponent } from './client/show-client/show-client.component';
import { ProjectComponent } from './project/project.component';
import { ShowProjectComponent } from './project/show-project/show-project.component';
import { PropertyComponent } from './property/property.component';
import { ShowPropertyComponent } from './property/show-property/show-property.component';
import { ContractComponent } from './contract/contract.component';
import { ShowContractComponent } from './contract/show-contract/show-contract.component';
import { PropertyconfigurationComponent } from './propertyconfiguration/propertyconfiguration.component';
import { ShowPropertyconfigurationComponent } from './propertyconfiguration/show-propertyconfiguration/show-propertyconfiguration.component';
import { ConfigurationitemComponent } from './configurationitem/configurationitem.component';
import { ShowConfigurationitemComponent } from './configurationitem/show-configurationitem/show-configurationitem.component';
import { ConfigurationoptionComponent } from './configurationoption/configurationoption.component';
import { ShowConfigurationoptionComponent } from './configurationoption/show-configurationoption/show-configurationoption.component';
import { PropertyconfigurationitemsComponent } from './propertyconfigurationitems/propertyconfigurationitems.component';
import { ShowPropertyconfigurationitemsComponent } from './propertyconfigurationitems/show-propertyconfigurationitems/show-propertyconfigurationitems.component';
import { AddEditClientComponent } from './client/add-edit-client/add-edit-client.component';
import { AddEditProjectComponent } from './project/add-edit-project/add-edit-project.component';
import { AddEditContractComponent } from './contract/add-edit-contract/add-edit-contract.component';
import { AddEditPropertyComponent } from './property/add-edit-property/add-edit-property.component';
import { AddEditPropertyconfigurationComponent } from './propertyconfiguration/add-edit-propertyconfiguration/add-edit-propertyconfiguration.component';
import { AddEditConfigurationitemComponent } from './configurationitem/add-edit-configurationitem/add-edit-configurationitem.component';
import { AddEditPropertyconfigurationitemsComponent } from './propertyconfigurationitems/add-edit-propertyconfigurationitems/add-edit-propertyconfigurationitems.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    DeveloperComponent,
    ShowDeveloperComponent,
    AddDeveloperComponent,
    ClientComponent,
    ShowClientComponent,
    ProjectComponent,
    ShowProjectComponent,
    PropertyComponent,
    ShowPropertyComponent,
    ContractComponent,
    ShowContractComponent,
    PropertyconfigurationComponent,
    ShowPropertyconfigurationComponent,
    ConfigurationitemComponent,
    ShowConfigurationitemComponent,
    ConfigurationoptionComponent,
    ShowConfigurationoptionComponent,
    PropertyconfigurationitemsComponent,
    ShowPropertyconfigurationitemsComponent,
    AddEditClientComponent,
    AddEditProjectComponent,
    AddEditContractComponent,
    AddEditPropertyComponent,
    AddEditPropertyconfigurationComponent,
    AddEditConfigurationitemComponent,
    AddEditPropertyconfigurationitemsComponent,
 
    
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      // { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'NavMenu-List', component:NavMenuComponent },
      { path: 'Developer-List', component: DeveloperComponent },
      { path: 'Client-List', component: ClientComponent },
      { path: 'Project-List', component: ProjectComponent },
      { path: 'Property-List', component: PropertyComponent },
      { path: 'Contract-List', component: ContractComponent },
      { path: 'PropertyConfiguration-List', component: PropertyconfigurationComponent },
      { path: 'Configurationitem-List', component: ConfigurationitemComponent },
      { path: 'Propertyconfigurationitems-List', component: PropertyconfigurationitemsComponent },
      { path: 'ConfigurationOption-List', component: ConfigurationoptionComponent },

    ])
  ],
  providers: [DeveloperApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
