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
      let _param = [];
      params["query"] === undefined
        ? _param.push("NaN")
        : _param = (params["query"].split(" "));

      console.log(_param)

      switch (_param[0]) {
        case 'sort':
          console.log(_param[0])
          this.candidateService.sort({ name: _param[1], arrow: _param[2] })
            .subscribe(result => this.users = result);
          break;
        case 'filter':
          this.candidateService.filter(JSON.parse(_param[1])).subscribe(result => {
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