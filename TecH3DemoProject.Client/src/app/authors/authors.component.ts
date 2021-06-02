import { Component, OnInit } from '@angular/core';
import { Author, Book } from '../models';
import { AuthorService } from '../author.service';
import { MessageService } from '../message.service';
import { Observable } from 'rxjs';


@Component({
   selector: 'app-authors',
   templateUrl: './authors.component.html',
   styleUrls: ['./authors.component.css']
})
export class AuthorsComponent implements OnInit {

   authors: Author[] = [];
   author?: Author;

   constructor(
      private authorService: AuthorService,
      private messageService: MessageService
   ) { }

   ngOnInit(): void {
      this.getAuthors();
   }


   getAuthors(): void {
      this.authorService.getAuthors()
         .subscribe(authors => this.authors = authors);
   }

   


   add(firstName: string, lastName: string): void {
      firstName = firstName.trim();
      lastName = lastName.trim();
      
      if (!firstName || !lastName) {
         return;
      }
      this.authorService.addAuthor({ firstName, lastName } as Author)
         .subscribe(author => {
            this.authors.push(author);
         })
         .unsubscribe();

   }

   delete(author: Author): void {
      if (confirm('Er du sikker?')) {
         this.authorService.deleteAuthor(author.id)
            .subscribe(author => {
               this.author = author;
               this.authors = this.authors.filter(a => a !== author);
            });
      }
   }

}
