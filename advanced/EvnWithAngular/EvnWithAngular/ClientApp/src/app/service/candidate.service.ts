import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CandidateService {
  baseUrl: String;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }
  create(data: any): Observable<any> {
    return this.http.post(this.baseUrl +'/candidate/create',data);
  }
  getAll(): Observable<any>{
    return this.http.get(this.baseUrl + '/candidate/all');
  }

  filter(data: any): Observable<any> {
    return this.http.post(this.baseUrl + '/candidate/filter', data);
  }
  saveToken(candidate: any) { localStorage.setItem('user', candidate); };

  getToken() { return localStorage.getItem('candidate'); };
}
