import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { Author } from './models';
import { AUTHORS } from './mock-authors';
import { MessageService } from './message.service';

@Injectable({
  providedIn: 'root'
})
export class AuthorService {

  private authorsUrl = 'https://localhost:5001/api/author';

  constructor(private http: HttpClient, private messageService: MessageService) { }


  getAuthors(): Observable<Author[]> {
    this.messageService.add('AuthorService: fetched authors');
    return this.http.get<any>(this.authorsUrl);
  }
}
