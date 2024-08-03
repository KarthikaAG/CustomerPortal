import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SigninComponent } from './sign-in/sign-in.component';
import { SignupComponent } from './sign-up/sign-up.component';
import { MyPoliciesComponent } from './my-policies/my-policies.component';

const routes: Routes = [
  { path: '', redirectTo: 'sign-in', pathMatch: 'full' },
  { path: 'sign-in', component: SigninComponent },
  { path: 'sign-up', component: SignupComponent },
  { path: 'my-policies', component: MyPoliciesComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
