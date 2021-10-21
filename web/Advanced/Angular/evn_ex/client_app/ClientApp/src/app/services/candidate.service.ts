import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';

import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CandidateService {
  private url: string;
  constructor(private http: HttpClient) {
    this.url = environment.appUrl;
  }

  getAll(): Observable<any> {
    return this.http.get(this.url + "/candidate/all");
  }
  create(data: any): Observable<any> {
    return this.http.post(this.url + "/candidate/create", data);
  }
  filter(data: any): Observable<any> {
    return this.http.post(this.url + "/candidate/filter", data);
  }
}
