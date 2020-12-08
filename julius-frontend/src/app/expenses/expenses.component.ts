import { Component, OnInit } from '@angular/core';
import {MatDialog} from '@angular/material/dialog';
import {ExpenseItem} from './expense-item/expense-item';
import {ExpenseItemComponent} from './expense-item/expense-item.component';
import {PaymentActionComponent} from './payment-action/payment-action.component';
import {PaymentAction} from './payment-action/PaymentAction';
import {AlertComponent} from '../alert/alert.component';
import {ExpenseService} from './expense-item/expense.service';
import {Month} from './expense-item/month';

@Component({
  selector: 'app-expenses',
  templateUrl: './expenses.component.html',
  styleUrls: ['./expenses.component.css']
})
export class ExpensesComponent implements OnInit {

  constructor(public dialog: MatDialog,
              public expenseService: ExpenseService) {}

  public displayedColumns: string[] = ['billingDate', 'description', 'totalValue', 'totalPaid', 'status', 'action'];

  public totalIncome = 50000;

  public dataSource: ExpenseItem[];

  public months: Month[];

  ngOnInit(): void {

    this.expenseService.getMonths().subscribe(response => {
      this.months = response;
      this.LoadData(response);
    });
  }

  openFinancialItemDialog(): void {
    const dialogRef = this.dialog.open(ExpenseItemComponent, {
      width: '250px',
      data: new ExpenseItem()
    });

    dialogRef.afterClosed().subscribe(expense => {
      expense.month = this.months[0].month;
      expense.year = this.months[0].year;

      this.expenseService.postExpense(expense).subscribe(() => {
        this.LoadData(this.months);
      });
    });
  }

  openPaymentActionDialog(expenseId: string): void {
    const dialogRef = this.dialog.open(PaymentActionComponent, {
      width: '250px',
      data: new PaymentAction(expenseId)
    });

    dialogRef.afterClosed().subscribe(paymentAction => {
      this.expenseService.postPaymentAction(paymentAction).subscribe(() => {
        this.LoadData(this.months);
      });
    });
  }

  openAlertDialog(id: string): void {
    const dialogRef = this.dialog.open(AlertComponent, {
      width: '250px'
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.expenseService.deleteExpense(id).subscribe(() => {
          this.LoadData(this.months);
        });
      }
    });
  }

  spendingForecast(): number {
    // return this.dataSource.reduce((x, {totalValue}) => x + totalValue, 0);
    return 0;
  }

  totalPaid(): number {
    // return this.dataSource.reduce((x, {totalPaid}) => x + totalPaid, 0);
    return 0;
  }

  private LoadData(response): void {
    this.expenseService.getExpensesByMonthAndYear(response[0].month, response[0].year).subscribe(expenses => {
      this.dataSource = expenses;
    });
  }
}

