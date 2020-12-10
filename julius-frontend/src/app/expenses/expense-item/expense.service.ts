import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {ExpenseItem} from './expense-item';
import {PaymentAction} from '../payment-action/PaymentAction';
import {Totals} from '../Totals';

@Injectable({
  providedIn: 'root'
})
export class ExpenseService {

  constructor(private http: HttpClient) { }

  public getExpensesByMonthAndYear(month: string, year: string): Observable<any> {
    return this.http.get<ExpenseItem[]>(`https://localhost:44300/api/Expense/GetExpensesBy/${month}/${year}`);
  }

  public getMonths(): Observable<any> {
    return this.http.get('https://localhost:44300/api/Expense/getMonths');
  }

  public postExpense(expenseItem: ExpenseItem): Observable<any> {
    return this.http.post('http://localhost:62672/api/Expense/AddExpense', expenseItem);
  }

  public postPaymentAction(paymentAction: PaymentAction): Observable<any> {
    return this.http.post('http://localhost:62672/api/Expense/PaymentAction', paymentAction);
  }

  public deleteExpense(id: string): Observable<any> {
    return this.http.delete(`http://localhost:62672/api/Expense/${id}`);
  }

  public getTotalsByMonthAndYear(month: string, year: string): Observable<any> {
    return this.http.get<Totals>(`https://localhost:44300/api/Expense/GetTotalsBy/${month}/${year}`);
  }
}
