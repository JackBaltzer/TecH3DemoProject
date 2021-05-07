import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';


import { Author } from './models';
import { MessageService } from './message.service';

@Injectable({
  providedIn: 'root'
})
export class AuthorService {

  private authorsUrl = 'https://localhost:5001/api/author';

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(
    private http: HttpClient,
    private messageService: MessageService) { }


  getAuthors(): Observable<Author[]> {
    return this.http.get<any>(this.authorsUrl).pipe(
      tap(_ => this.log('fetched authors')),
      catchError(this.handleError<Author[]>('getAuthors', []))
    );
  }

  getAuthor(id: number): Observable<Author> {
    return this.http.get<Author>(`${this.authorsUrl}/${id}`).pipe(
      tap(_ => this.log(`fetched author with id=${id}`)),
      catchError(this.handleError<Author>(`getAuthor id=${id}`))
    );
  }

  updateAuthor(author: Author): Observable<any> {
    return this.http.put(`${this.authorsUrl}/${author.id}`, author, this.httpOptions).pipe(
      tap(_ => this.log(`updated author id=${author.id}`)),
      catchError(this.handleError<any>('updateAuthor'))
    );
  }

  /**
   * Handle Http operation that failed.
   * Let the app continue.
   * @param operation - name of the operation that failed
   * @param result - optional value to return as the observable result
   */
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };

  }

  /** Log a AuthorService message with the MessageService */
  private log(message: string) {
    this.messageService.add(`AuthorService: ${message}`);
  }
}
