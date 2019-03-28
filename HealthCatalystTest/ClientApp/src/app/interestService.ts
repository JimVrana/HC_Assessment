import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { interest } from './interest'

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({ providedIn: 'root' })
export class interestService {
  private interestUrl = 'api/interest';  
  constructor(private http: HttpClient) { }

  getInterests(): Observable<interest[]> {
    return this.http.get<interest[]>(this.interestUrl)
      .pipe(
        catchError(this.handleError<interest[]>('getInterests', []))
      );
  }

  getInterestsForPerson(id: number): Observable<interest[]> {
    const url = `${this.interestUrl}/${id}`;
    console.log(url);
    return this.http.get<interest[]>(url)
      .pipe(
        catchError(this.handleError<interest[]>('getInterestsForPerson', []))
      );
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error); 
      return of(result as T);
    };
  }

}