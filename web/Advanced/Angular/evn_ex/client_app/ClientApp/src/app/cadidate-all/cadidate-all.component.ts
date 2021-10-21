import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CandidateService } from '../services/candidate.service';

@Component({
  selector: 'app-cadidate-all',
  templateUrl: './cadidate-all.component.html',
  styles: [
  ]
})
export class CadidateAllComponent implements OnInit {

  public users: User[] = [];
  constructor(

    private activateRouter: ActivatedRoute,
    private candidateService: CandidateService) {

    this.activateRouter.queryParams.subscribe(params => {
      try {
        this.users = JSON.parse(params["users"])
      } catch {

        this.candidateService.getAll().subscribe(result => this.users = result)
      }


    }
    )

  }

  ngOnInit(): void {

  }

}
export interface User {
  id: number;
  fullName: string;
  departmentName: string;
  code: string;
  education: string;
  birthDate: Date;
  score: string;
}