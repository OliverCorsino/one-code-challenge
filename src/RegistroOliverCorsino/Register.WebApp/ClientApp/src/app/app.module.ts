import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { AboutComponent } from './components/about/about.component';
import { RegistrationComponent } from './components/registration/registration.component';
import { RequestsComponent } from './components/requests/requests.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { UserService } from './services/user.service';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    RegistrationComponent,
    AboutComponent,
    RequestsComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: RegistrationComponent },
      { path: 'about', component: AboutComponent },
      { path: 'requests', component: RequestsComponent },
    ])
  ],
  providers: [
    UserService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
