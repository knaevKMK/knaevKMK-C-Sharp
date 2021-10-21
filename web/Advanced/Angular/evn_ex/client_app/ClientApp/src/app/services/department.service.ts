import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {
  private url: string;
  constructor(private http: HttpClient) {
    this.url = environment.appUrl;
  }

  getAll(): Observable<any> {
    return this.http.get(this.url + "/department/all")
  }

}
