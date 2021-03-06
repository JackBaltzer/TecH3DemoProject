import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { AuthorService } from '../author.service';
import { Author } from '../models';


@Component({
   selector: 'app-author-detail',
   templateUrl: './author-detail.component.html',
   styleUrls: ['./author-detail.component.css']
})
export class AuthorDetailComponent implements OnInit {
   author: Author;

   constructor(
      private route: ActivatedRoute,
      private authorService: AuthorService,
      private location: Location
   ) { }

   ngOnInit(): void {
      this.getAuthor();
   }

   getAuthor(): void {
      const id = +this.route.snapshot.paramMap.get('id');
      this.authorService.getAuthor(id)
         .subscribe(author => this.author = author);
   }

   save(): void {
      this.authorService.updateAuthor(this.author)
        .subscribe(() => this.goBack());
   }

   goBack(): void {
      this.location.back();
   }
}
