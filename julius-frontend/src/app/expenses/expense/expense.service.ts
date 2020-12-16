import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {Expense} from './expense';
import {PaymentAction} from '../payment-action/PaymentAction';
import {Totals} from '../Totals';

@Injectable({
  providedIn: 'root'
})
export class ExpenseService {

  constructor(private http: HttpClient) { }

  public getExpensesByMonthAndYear(periodId: string): Observable<any> {
    return this.http.get<Expense[]>(`https://localhost:44300/api/Expense/GetExpensesBy/${periodId}`);
  }

  public postExpense(expenseItem: Expense): Observable<any> {
    return this.http.post('http://localhost:44300/api/Expense/AddExpense', expenseItem);
  }

  public postPaymentAction(paymentAction: PaymentAction): Observable<any> {
    return this.http.post('http://localhost:44300/api/Expense/PaymentAction', paymentAction);
  }

  public deleteExpense(id: string): Observable<any> {
    return this.http.delete(`http://localhost:44300/api/Expense/${id}`);
  }

  public getTotalsByMonthAndYear(periodId: string): Observable<any> {
    return this.http.get<Totals>(`https://localhost:44300/api/Expense/GetTotalsBy/${periodId}`);
  }
}
