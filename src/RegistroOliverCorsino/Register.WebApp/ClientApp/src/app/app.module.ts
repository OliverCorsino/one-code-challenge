import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { UserInfoComponent } from './components/user-info/user-info.component';
import { RegistrationComponent } from './components/registration/registration.component';
import { RequestsComponent } from './components/requests/requests.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { ContactInformationTypeService } from './services/contact-information-type.service';
import { EducationLevelService } from './services/education-level.service';
import { UserService } from './services/user.service';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    RegistrationComponent,
    UserInfoComponent,
    RequestsComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: RegistrationComponent },
      { path: 'users', component: UserInfoComponent },
      { path: 'requests', component: RequestsComponent },
    ])
  ],
  providers: [
    UserService,
    EducationLevelService,
    ContactInformationTypeService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
