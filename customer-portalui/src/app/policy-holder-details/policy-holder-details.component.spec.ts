import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PolicyHolderDetailsComponent } from './policy-holder-details.component';

describe('PolicyHolderDetailsComponent', () => {
  let component: PolicyHolderDetailsComponent;
  let fixture: ComponentFixture<PolicyHolderDetailsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PolicyHolderDetailsComponent]
    });
    fixture = TestBed.createComponent(PolicyHolderDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
