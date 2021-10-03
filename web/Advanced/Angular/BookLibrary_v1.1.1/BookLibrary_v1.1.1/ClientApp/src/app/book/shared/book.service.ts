import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Book } from './book.model';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  constructor(private http: HttpClient) { }

  formData: Book = {
    title: null,
    authorName: null,
    id: null
  };

  readonly rootUrl = 'http://localhost:32811/api/Book';
  list: Book[];

  postBook() {
    return this.http.post(this.rootUrl, this.formData);
  }
  putBook() {
    return this.http.put(this.rootUrl + "/" + this.formData.id, this.formData);
  }
  deleteBook(id) {
    return this.http.delete(this.rootUrl + "/" + id,)
  }
  loadList() {
    return this.http.get(this.rootUrl)
      .toPromise()
      .then(result => this.list = result as Book[]);
  }

}
