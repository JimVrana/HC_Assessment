import { Component, Inject, OnInit, HostListener } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Person } from '../Person';
import { PersonService } from '../PersonService';
import { interest } from '../interest';
import { interestService } from '../interestService';
import { Ng4LoadingSpinnerService } from 'ng4-loading-spinner';
import { fromEvent, Observable, of, Subject } from 'rxjs';
import { ajax } from 'rxjs/ajax';
import { map, filter, debounceTime, distinctUntilChanged, switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-people',
  templateUrl: './people.component.html'
})
export class PeopleComponent implements OnInit {
  people$: Observable<Person[]>;
  interests: interest[];
  private searchTerms = new Subject<string>();
  selectedPerson: Person;

  constructor(private personService: PersonService, private interestService: interestService, private spinnerService: Ng4LoadingSpinnerService) { }

  //add in a delay to simulate slow server results
  search(term: string): void {
    this.spinnerService.show();
    this.delay(1500).then(any => {
      this.searchTerms.next(term);
      this.spinnerService.hide();
    });
  }

  ngOnInit(): void {
    this.people$ = this.searchTerms.pipe(
      debounceTime(300),
      distinctUntilChanged(),
      switchMap((term: string) => this.personService.searchPeople(term)),
    );
  }

  //get interests for the person
  getInterestForPerson(id: number): void {
    console.log(id);
    this.interestService.getInterestsForPerson(id)
      .subscribe(interests => this.interests = interests);
  }

  //create delays 
  async delay(ms: number) {
    await new Promise(resolve => setTimeout(() => resolve(), ms)).then(() => console.log("fired"));
  }

  //show details for a person and get their interests
  onSelect(person: Person): void {
    this.spinnerService.show();
    this.delay(1500).then(any => {
      this.selectedPerson = person;
      this.getInterestForPerson(person.id);
      this.spinnerService.hide();
    });
  }
}
