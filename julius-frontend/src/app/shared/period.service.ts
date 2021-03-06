import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PeriodService {

  constructor(private http: HttpClient) { }

  public getPeriods(): Observable<any> {
    return this.http.get('https://localhost:44300/api/Period/getPeriods');
  }
}
