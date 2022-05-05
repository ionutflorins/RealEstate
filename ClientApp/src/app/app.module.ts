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
    
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
    ])
  ],
  providers: [DeveloperApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
