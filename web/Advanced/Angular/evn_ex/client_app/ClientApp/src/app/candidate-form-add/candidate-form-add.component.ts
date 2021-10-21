import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CandidateService } from '../services/candidate.service';
import { DepartmentService } from '../services/department.service';

@Component({
  selector: 'app-candidate-form-add',
  templateUrl: './candidate-form-add.component.html',
  styles: [
  ]
})
export class CandidateFormAddComponent implements OnInit {
  public createForm: FormGroup;
  public departments: Deparment[] = [];

  constructor(private router: Router,
    private fb: FormBuilder,
    private userService: CandidateService,
    private departmentService: DepartmentService) {
    this.createForm = this.fb.group({
      'fullName': ['', Validators.required],
      'departmentName': ['Select...', Validators.required],
      'birthDate': [Date.now(), Validators.required],
      'education': ['', Validators.required],
      'score': [0, Validators.required]
    });
  }

  ngOnInit(): void {
    //  debugger;
    this.departmentService.getAll().subscribe(data => this.departments = data)
  }

  onCreate() {
    this.userService.create(this.createForm.value).subscribe(data => this.router.navigate(['/']))

  }


  get fullName() { return this.createForm.get('fullName'); }
  get departmentName() { return this.createForm.get('departmentName'); }
  get birthDate() { return this.createForm.get('birthDate'); }
  get education() { return this.createForm.get('education'); }
  get score() { return this.createForm.get('score'); }
}

export interface Deparment {
  name: string;
  code: number;
}