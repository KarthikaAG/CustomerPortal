import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-policy-holder-details',
  templateUrl: './policy-holder-details.component.html',
  styleUrls: ['./policy-holder-details.component.css']
})
export class PolicyHolderDetailsComponent {
  @Input() policy: any;
}
