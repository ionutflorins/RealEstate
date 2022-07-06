import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';

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
import { UserComponent } from './user/user.component';
import { RegistrationComponent } from './user/registration/registration.component';
import { UserService } from './Service/user.service';
import { LoginComponent } from './user/login/login.component';
import { AuthGuard } from './auth/auth.guard';
import { AuthInterceptor } from './auth/auth.interceptor';
import { AdminPanelComponent } from './admin-panel/admin-panel.component';
import { ForbiddenComponent } from './forbidden/forbidden.component';
import { ClientFormComponent } from './client-form/client-form.component';
import { AddEditConfigurationoptionComponent } from './configurationoption/add-edit-configurationoption/add-edit-configurationoption.component';

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
    UserComponent,
    RegistrationComponent,
    LoginComponent,
    AdminPanelComponent,
    ForbiddenComponent,
    ClientFormComponent,
    AddEditConfigurationoptionComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      progressBar: true
    }),
    RouterModule.forRoot([
      // { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: '', redirectTo: '/user/login', pathMatch: 'full' },
      { path: 'NavMenu-List', component: NavMenuComponent },
      { path: 'Developer-List', component: DeveloperComponent, canActivate: [AuthGuard], data: { permittedRoles: ['Admin', 'Developer'] }},
      {
        path: 'Client-List', component: ClientComponent, children: [
          { path: '', pathMatch: 'full', component: ShowClientComponent },
          { path: ':id', pathMatch: 'full', component: ShowClientComponent }
        ]
      },
      {
        path: 'Project-List', component: ProjectComponent,canActivate: [AuthGuard], data: { permittedRoles: ['Admin', 'Developer'] } ,  children: [
          { path: '', pathMatch: 'full', component: ShowProjectComponent },
          { path: ':id', pathMatch: 'full', component: ShowProjectComponent }
        ]
      },
      {
        path: 'Property-List', component: PropertyComponent, canActivate: [AuthGuard], data: { permittedRoles: ['Admin', 'Developer'] }  , children: [
          { path: '', pathMatch: 'full', component: ShowPropertyComponent },
          { path: ':id', pathMatch: 'full', component: ShowPropertyComponent }
        ]
      },
      { path: 'Contract-List', component: ContractComponent, canActivate: [AuthGuard], data: { permittedRoles: ['Admin', 'Developer', 'Client'] }  , children: [
        { path: '', pathMatch: 'full', component: ShowContractComponent },
        { path: ':id', pathMatch: 'full', component: ShowContractComponent }
      ] },
      { path: 'PropertyConfiguration-List', component: PropertyconfigurationComponent, canActivate: [AuthGuard], data: { permittedRoles: ['Admin', 'Developer', 'Client'] }},
      { path: 'Configurationitem-List', component: ConfigurationitemComponent, canActivate: [AuthGuard], data: { permittedRoles: ['Admin', 'Developer'] } },
      { path: 'Propertyconfigurationitems-List', component: PropertyconfigurationitemsComponent, canActivate: [AuthGuard], data: { permittedRoles: ['Admin', 'Developer', 'Client'] } },
      { path: 'ConfigurationOption-List', component: ConfigurationoptionComponent, canActivate: [AuthGuard], data: { permittedRoles: ['Admin', 'Developer'] } },
      {
        path: 'user', component: UserComponent, children: [
          { path: 'registration', component: RegistrationComponent },
          { path: 'login', component: LoginComponent }
        ]
      },
      { path: 'home', component: HomeComponent, canActivate: [AuthGuard] },
      { path: 'forbidden', component: ForbiddenComponent },
      { path: 'admin', component: AdminPanelComponent, canActivate: [AuthGuard], data: { permittedRoles: ['Admin', 'Developer'] } },
      { path: 'client-form', component: ClientFormComponent }
    ])
  ],
  providers: [DeveloperApiService, UserService, {
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
