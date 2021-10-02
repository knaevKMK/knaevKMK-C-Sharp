import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { error } from 'protractor';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public books: Book[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Book>(baseUrl + 'book')
      .subscribe(result => { this.books = result; }, error => console.error(error));
  }
}

interface Book {
  title: string,
  author: string,
  isbn:string
}
