import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Book } from './book.model';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  constructor(private http: HttpClient) { }
  readonly baseUrl = 'http://localhost:61236/api/Book';
  formdata: Book = new Book();
}
