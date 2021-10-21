import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CadidateAllComponent } from './cadidate-all.component';

describe('CadidateAllComponent', () => {
  let component: CadidateAllComponent;
  let fixture: ComponentFixture<CadidateAllComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CadidateAllComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CadidateAllComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
