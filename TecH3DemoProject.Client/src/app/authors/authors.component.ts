import { Component, OnInit } from '@angular/core';
import { Author, Book } from '../models';
import { AUTHORS } from '../mock-authors';
import { AuthorService } from '../author.service';
import { MessageService } from '../message.service';


@Component({
  selector: 'app-authors',
  templateUrl: './authors.component.html',
  styleUrls: ['./authors.component.css']
})
export class AuthorsComponent implements OnInit {

  authors: Author[] = [];
  author?: Author;

  constructor(private authorService: AuthorService, private messageService: MessageService) { }

  ngOnInit(): void {
    this.getAuthors();
  }


  getAuthors(): void {
    this.authorService.getAuthors().subscribe(authors => this.authors = authors);
  }

  onSelect(author: Author): void {
    this.messageService.add(`AuthorComponent: selected author id=${author.id}`);
    this.author = author;
  }

}
