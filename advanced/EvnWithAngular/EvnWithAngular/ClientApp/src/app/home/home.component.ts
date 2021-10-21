import { Component, OnInit } from '@angular/core';
import { CandidateService } from '../service/candidate.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  public users: User[];

  constructor( private candidateService: CandidateService) {
   this.candidateService.getAll().subscribe(result => this.users = result);
  }
    ngOnInit() {
       
    }
}
interface User {
  id: number;
  fullName: string;
  department: string;
  code: string;
  education: string;
  birthDate: Date;
  score: number;
}
