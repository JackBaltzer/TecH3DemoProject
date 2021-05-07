import { Component, OnInit } from '@angular/core';
import { AuthorService } from '../author.service';
import { Author } from '../models';



@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  authors: Author[] = []; // explicit initialization needed, not in tutorial

  constructor(
    private authorService: AuthorService
  ) { }

  ngOnInit(): void {
    this.getAuthors();
  }

  getAuthors(): void {
    this.authorService.getAuthors()
      .subscribe(a => this.authors = a);
  }

}
