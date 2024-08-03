import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-coverage-details',
  templateUrl: './coverage-details.component.html',
  styleUrls: ['./coverage-details.component.css']
})
export class CoverageDetailsComponent {
  @Input() policy: any;
}
