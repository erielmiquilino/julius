import { Component, OnInit } from '@angular/core';
import {MatDialog} from '@angular/material/dialog';
import {ExpenseItem} from './expense-item/expense-item';
import {ExpenseItemComponent} from './expense-item/expense-item.component';
import {PaymentActionComponent} from '../payment-action/payment-action.component';
import {PaymentAction} from '../payment-action/PaymentAction';
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
      this.expenseService.getExpensesByMonthAndYear(response[0].month, response[0].year).subscribe(expenses => {
        this.dataSource = expenses;
      });
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

      this.expenseService.postExpense(expense).subscribe(result => {
        this.dataSource.push(result);
      });
    });
  }

  openPaymentActionDialog(): void {
    const dialogRef = this.dialog.open(PaymentActionComponent, {
      width: '250px',
      data: new PaymentAction()
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
    });
  }

  openAlertDialog(): void {
    this.dialog.open(AlertComponent, {});
  }

  spendingForecast(): number {
    // return this.dataSource.reduce((x, {totalValue}) => x + totalValue, 0);
    return 0;
  }

  totalPaid(): number {
    // return this.dataSource.reduce((x, {totalPaid}) => x + totalPaid, 0);
    return 0;
  }
}

