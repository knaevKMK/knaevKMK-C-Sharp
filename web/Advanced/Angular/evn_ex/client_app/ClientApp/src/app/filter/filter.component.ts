import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CandidateService } from '../services/candidate.service';
import { DepartmentService } from '../services/department.service';
import { Deparment } from '../candidate-form-add/candidate-form-add.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-filter',
  templateUrl: './filter.component.html',
  styles: [
  ]
})
export class FilterComponent implements OnInit {
  public filterForm: FormGroup;
  public departments: Deparment[] = [];



  constructor(
    private router: Router,
    private fb: FormBuilder,
    private userService: CandidateService,
    private deprtmentService: DepartmentService) {

    this.filterForm = this.fb.group({
      'name': [null, Validators.required],
      'department': ["Select...", Validators.required],
      'education': [null, Validators.required],
      'score': [null, Validators.required],
      'arrowScore': ["Current", Validators.required],
      'birthYaer': [null, Validators.required],
      'arrowBirth': ["Current", Validators.required]
    });

  }

  ngOnInit(): void {
    this.deprtmentService.getAll().subscribe(data => this.departments = data)
  }
  onFilter() {
    this.checkOptionField();

    this.router.navigate(['/'], { queryParams: { "query": "filter " + JSON.stringify(this.filterForm.value) } });
  }

  checkOptionField() {
    this.filterForm.value['department'] = this.filterForm.value['department'] == "Select..."
      ? null
      : this.filterForm.value['department'];
    this.filterForm.value['arrowScore'] = this.filterForm.value['arrowScore'] == "Current"
      ? null
      : this.filterForm.value['arrowScore'];
    this.filterForm.value['arrowBirth'] = this.filterForm.value['arrowBirth'] == "Current"
      ? null
      : this.filterForm.value['arrowBirth'];
  }
  get name() { return this.filterForm.get('name') }
  get department() { return this.filterForm.get('department') }
  get education() { return this.filterForm.get('education') }
  get score() { return this.filterForm.get('score') }
  get arrowScore() { return this.filterForm.get('arrowScore') }
  get birthYaer() { return this.filterForm.get('birthYaer') }
  get arrowBirth() { return this.filterForm.get('arrowBirth') }
}
