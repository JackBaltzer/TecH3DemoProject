import { Component, OnInit } from '@angular/core';
import { Author, Book } from '../models';
import { AUTHORS } from '../mock-authors';

@Component({
  selector: 'app-authors',
  templateUrl: './authors.component.html',
  styleUrls: ['./authors.component.css']
})
export class AuthorsComponent implements OnInit {

  authors = AUTHORS;
  author?: Author;

  constructor() { }

  ngOnInit(): void {
  }

  onSelect(author: Author):void{
    this.author = author;
  }

}
