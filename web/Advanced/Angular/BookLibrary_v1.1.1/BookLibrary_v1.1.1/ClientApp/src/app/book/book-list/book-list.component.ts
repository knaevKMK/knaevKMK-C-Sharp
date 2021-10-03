import { Component, OnInit } from '@angular/core';
import { BookService } from '../shared/book.service';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.css']
})
export class BookListComponent implements OnInit {

  constructor(public service: BookService) { }

  ngOnInit() {
    this.service.loadList();
  }
  onDelete(id) {
    this.service.deleteBook(id)
      .subscribe(result => {
        debugger;
        this.service.loadList();
      },
        err => { debugger; console.log(err); }
      )
  }
  onEdit(id) {
    //todo
  }
}
