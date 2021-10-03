import { Component, OnInit } from '@angular/core';
import { BookService } from '../shared/book.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-book-form',
  templateUrl: './book-form.component.html',
  styleUrls: ['./book-form.component.css']
})
export class BookFormComponent implements OnInit {

  constructor(public service: BookService) { }

  ngOnInit() {
  }
  resetForm(form?: NgForm) {
    if (form != null)
      form.form.reset();
    this.service.formData = {
      id: 0,
      authorName: '',
      title: ''
    }
  }

  onSubmit(form: NgForm) {
    if (this.service.formData.id == 0)
      this.insertRecord(form);
    else
      this.updateRecord(form);
  }
  insertRecord(form: NgForm) {
    this.service.postBook()
      .subscribe(result => {
        debugger;
        this.resetForm(form);
        this.service.loadList();
      },

        err => { debugger; console.log(err) });
  }

  updateRecord(form: NgForm) {
    this.service.putBook()
      .subscribe(result => {
        debugger;
        this.resetForm(form);
        this.service.loadList();
      },

        err => { debugger; console.log(err) });

  }

}
