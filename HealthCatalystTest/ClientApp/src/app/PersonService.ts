import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap, switchMap, debounceTime, distinctUntilChanged } from 'rxjs/operators';
import { Person } from './Person'

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({ providedIn: 'root' })
export class PersonService {
  private peopleUrl = 'api/people';
  constructor(private http: HttpClient) { }

  getPeople(): Observable<Person[]> {
    return this.http.get<Person[]>(this.peopleUrl)
      .pipe(
        catchError(this.handleError<Person[]>('getPeople', []))
      );
  }

  getPersonNo404<Data>(id: number): Observable<Person> {
    const url = `${this.peopleUrl}/?id=${id}`;
    return this.http.get<Person[]>(url)
      .pipe(
        map(people => people[0]),
        catchError(this.handleError<Person>(`getPerson id=${id}`))
      );
  }

  getPerson(id: number): Observable<Person> {
    const url = `${this.peopleUrl}/${id}`;
    return this.http.get<Person>(url).pipe(
      catchError(this.handleError<Person>(`getPerson id=${id}`))
    );
  }

  searchPeople(term: string): Observable<Person[]> {
    var people: Observable<Person[]>;
    if (!term) {
      return of([]);
    }
    people = this.http.get<Person[]>(`${this.peopleUrl}/?q=${term}`).pipe(
      catchError(this.handleError<Person[]>('searchPeople', []))
    );
    return people;
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      return of(result as T);
    };
  }


}