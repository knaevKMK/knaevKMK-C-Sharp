import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment.prod'
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor(private http: HttpClient) { }

  login(data): Observable<any> {
    return this.http.post(environment.apiUrl + 'login', data)
  }
  register(data): Observable<any> {
    return this.http.post(environment.apiUrl + 'register', data);
  }
}
