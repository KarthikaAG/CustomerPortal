import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { PolicyService } from '../services/policy.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-my-policies',
  templateUrl: './my-policies.component.html',
  styleUrls: ['./my-policies.component.css']
})
export class MyPoliciesComponent implements OnInit {
  userFullName: string = '';
  policies: any[] = [];
  selectedPolicy: any = null;
  policyNumber: string = '';
  chassisNumber: string = '';

  constructor(private authService: AuthService, private policyService: PolicyService, private router: Router) {}

  ngOnInit() {
    this.userFullName = this.authService.getFullName();
    this.loadPolicies();
  }

  loadPolicies() {
    this.policyService.getUserPolicies().subscribe((data: any) => {
      this.policies = data;
    });
  }

  addPolicy() {
    this.policyService.addPolicy(this.policyNumber, this.chassisNumber).subscribe(() => {
      this.loadPolicies();
    });
  }

  removePolicy(policyNumber: string) {
    this.policyService.removePolicy(policyNumber).subscribe(() => {
      this.loadPolicies();
    });
  }

  onPolicySelect(policy: any) {
    this.selectedPolicy = policy;
  }

  logout() {
    this.authService.logout();
    this.router.navigate(['/sign-in']);
  }
}
