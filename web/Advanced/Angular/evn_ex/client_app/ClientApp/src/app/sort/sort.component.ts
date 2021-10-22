import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CandidateService } from '../services/candidate.service';
import { NavigationExtras, Router } from "@angular/router";

@Component({
  selector: 'app-sort',
  templateUrl: './sort.component.html',
  styles: [
  ]
})
export class SortComponent implements OnInit {
  public sortForm: FormGroup;

  constructor(private fb: FormBuilder,
    private router: Router,
    private userService: CandidateService) {

    this.sortForm = this.fb.group({
      'idSort': [null],
      'nameSort': [null, Validators.required],
      'departmentSort': [null, Validators.required],
      'educationSort': [null, Validators.required],
      'scoreSort': [null, Validators.required],
      'birthYearSort': [null, Validators.required]
    });
  }

  ngOnInit(): void {
  }
  onSort() {
    this.router.navigate(['/'], { queryParams: { "query": JSON.stringify(this.sortForm.value) } });
  }

  get idSort() { return this.sortForm.get('idSort') }
  get nameSort() { return this.sortForm.get('nameSort') }
  get departmentSort() { return this.sortForm.get('departmentSort') }
  get educationSort() { return this.sortForm.get('educationSort') }
  get scoreSort() { return this.sortForm.get('scoreSort') }
  get birthYearSort() { return this.scoreSort?.get('birthYearSort') }
}
