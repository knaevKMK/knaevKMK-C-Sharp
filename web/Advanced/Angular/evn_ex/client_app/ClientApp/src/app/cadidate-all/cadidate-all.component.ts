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
      //  console.log(params["query"])
      let token = params["query"] === undefined
        ? ["NaN"]
        : params["query"].split(" ");

      switch (token[0]) {
        case 'sort':
          this.candidateService.sort({ name: token[1], arrow: token[2] })
            .subscribe(result => this.users = result);
          break;
        case 'filter':
          console.log(token)
          this.candidateService.filter(JSON.parse(token[1])).subscribe(result => {
            console.log(result);
            this.users = result;
          })

          break;
        default:
          this.candidateService.getAll().subscribe(result => this.users = result); break;
      }

    })
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