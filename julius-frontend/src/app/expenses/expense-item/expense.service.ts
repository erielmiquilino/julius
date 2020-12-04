import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {ExpenseItem} from './expense-item';

@Injectable({
  providedIn: 'root'
})
export class ExpenseService {

  constructor(private http: HttpClient) { }

  public getExpensesByMonthAndYear(month: string, year: string): Observable<any> {
    return this.http.get<ExpenseItem[]>(`https://localhost:44300/api/Expense/GetExpensesByMonthAndYear/${month}/${year}`);
  }

  public getMonths(): Observable<any> {
    return this.http.get('https://localhost:44300/api/Expense/getMonths');
  }

  public postExpense(expenseItem: ExpenseItem): Observable<any> {
    return this.http.post('http://localhost:62672/api/Expense/AddExpense', expenseItem);
  }
}