import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CandidateFormAddComponent } from './candidate-form-add.component';

describe('CandidateFormAddComponent', () => {
  let component: CandidateFormAddComponent;
  let fixture: ComponentFixture<CandidateFormAddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CandidateFormAddComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CandidateFormAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
