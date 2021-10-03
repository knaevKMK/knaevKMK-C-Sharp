import { Component, OnInit } from '@angular/core';
import { BookService } from './shared/book.service';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css']
})
export class BookComponent implements OnInit {

  constructor(public service: BookService) { }

  ngOnInit() {
  }
  onLoad() {
    this.service.loadList();
  }
}
