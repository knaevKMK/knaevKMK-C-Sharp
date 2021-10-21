import { error } from '@angular/compiler/src/util';
import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CandidateService } from '../service/candidate.service';
import { DepartmentService } from '../service/department.service';
import { NgModule } from '@angular/core';

@Component({
  selector: 'app-form-candidate',
  templateUrl: './form-candidate.component.html',
  styleUrls: ['./form-candidate.component.css']
})
export class FormCandidateComponent implements OnInit {
  public formGoup: FormGroup;
  public deparments: Department[];

  constructor(private fb: FormBuilder,
    private departmentService: DepartmentService
    , private candidateService: CandidateService) {

    

  }

  ngOnInit() {
    debugger;
    this.departmentService.getAll().subscribe(result => { this.deparments = result }, error => console.log(error));

    this.formGoup = this.fb.group({
      'fullName': ['', Validators.required],
      'code': ['', Validators.required],
      'departmentName': ['', Validators.required],
      'birthDate': ['', Validators.required],
      'education': ['', Validators.required]
    });}
  onCreate() {

    this.candidateService.create(this.formGoup.value).subscribe(data => {
        this.candidateService.saveToken(data['user']);
      });
    }
  

  get fullName() { return this.formGoup.get('fullName'); }
  get code() { return this.formGoup.get('Code');}
  get departmentName() { return this.formGoup.get('departmentName'); }
  get birthDate() { return this.formGoup.get('birthDate'); }
  get education() { return this.formGoup.get('education');}
}
interface Department {
  name: string;
  code: number;
}


  

                                                         
