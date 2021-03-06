import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment'
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor(private http: HttpClient) { }

  login(data: any): Observable<any> {
    return this.http.post(environment.appUrl + 'user/login', data);
  }

  register(data: any): Observable<any> {
    return this.http.post(environment.appUrl + 'user/register', data);
  }

  saveToken(token: any) { localStorage.setItem('token', token); };

  getToken() { return localStorage.getItem('token'); };
}
