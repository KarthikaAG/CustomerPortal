import { Component, Input, OnInit } from '@angular/core';
import { Policy } from '../models/policy';

@Component({
  selector: 'app-policy-details',
  templateUrl: './policy-details.component.html',
  styleUrls: ['./policy-details.component.css']
})
export class PolicyDetailsComponent implements OnInit {
  @Input() policy: Policy | null = null;

  constructor(private policyService: PolicyService) { }

  ngOnInit(): void {
    this.policyService.getPolicyDetails().subscribe((data: Policy) => {
      this.policy = data;
    });
  }
}
