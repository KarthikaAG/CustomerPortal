import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RouterModule } from '@angular/router';
import { PolicyService } from './services/policy.service'; // Make sure this path is correct
import { SigninComponent } from './sign-in/sign-in.component';
import { SignupComponent } from './sign-up/sign-up.component';
import { MyPoliciesComponent } from './my-policies/my-policies.component';
import { PolicyHolderDetailsComponent } from './policy-holder-details/policy-holder-details.component';
import { PolicyDetailsComponent } from './policy-details/policy-details.component';
import { CoverageDetailsComponent } from './coverage-details/coverage-details.component';
import { VehicleDetailsComponent } from './vehicle-details/vehicle-details.component';

@NgModule({
  declarations: [
    AppComponent,
    SigninComponent,
    SignupComponent,
    PolicyService,
    MyPoliciesComponent,
    PolicyHolderDetailsComponent,
    PolicyDetailsComponent,
    CoverageDetailsComponent,
    VehicleDetailsComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule,
    AppRoutingModule,
  ],
  providers: [PolicyService],
  bootstrap: [AppComponent],
})
export class AppModule { }
