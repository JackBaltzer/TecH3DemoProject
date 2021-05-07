import { Component, OnInit, Input } from '@angular/core';
import {Author} from '../models';


@Component({
  selector: 'app-author-detail',
  templateUrl: './author-detail.component.html',
  styleUrls: ['./author-detail.component.css']
})
export class AuthorDetailComponent implements OnInit {

  @Input() author?: Author;

  constructor() { }

  ngOnInit(): void {
  }

}