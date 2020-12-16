import { Component, OnInit } from '@angular/core';
import {MatDialog} from '@angular/material/dialog';
import {Expense} from './expense/expense';
import {ExpenseItemComponent} from './expense/expense-item.component';
import {PaymentActionComponent} from './payment-action/payment-action.component';
import {PaymentAction} from './payment-action/PaymentAction';
import {AlertComponent} from '../alert/alert.component';
import {ExpenseService} from './expense/expense.service';
import {Period} from '../shared/period';
import {Totals} from './Totals';
import {PeriodService} from '../shared/period.service';

@Component({
  selector: 'app-expenses',
  templateUrl: './expenses.component.html',
  styleUrls: ['./expenses.component.css']
})
export class ExpensesComponent implements OnInit {

  constructor(public dialog: MatDialog,
              public expenseService: ExpenseService,
              public periodService: PeriodService) {}

  public displayedColumns: string[] = ['billingDate', 'description', 'totalValue', 'totalPaid', 'status', 'action'];

  public dataSource: Expense[];

  public periods: Period[];
  public selectedPeriod: Period;

  public totals: Totals;

  ngOnInit(): void {
    this.totals = new Totals();
    this.periodService.getPeriods().subscribe(response => {
      this.periods = response;
      this.selectedPeriod = response[0];
      this.LoadData(this.selectedPeriod.id);
      this.LoadTotals(this.selectedPeriod.id);
    });
  }

  openFinancialItemDialog(): void {
    const dialogRef = this.dialog.open(ExpenseItemComponent, {
      width: '250px',
      data: new Expense()
    });

    dialogRef.afterClosed().subscribe(expense => {
      expense.month = this.periods[0].month;
      expense.year = this.periods[0].year;

      this.expenseService.postExpense(expense).subscribe(() => {
        this.LoadData(this.selectedPeriod.id);
        this.LoadTotals(this.selectedPeriod.id);
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
        this.LoadData(this.selectedPeriod.id);
        this.LoadTotals(this.selectedPeriod.id);
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
          this.LoadData(this.selectedPeriod.id);
          this.LoadTotals(this.selectedPeriod.id);
        });
      }
    });
  }

  private LoadTotals(periodId: string): void {
    this.expenseService.getTotalsByMonthAndYear(periodId).subscribe(totals => {
      this.totals = totals;
    });
  }

  private LoadData(periodId: string): void {
    this.expenseService.getExpensesByMonthAndYear(periodId).subscribe(expenses => {
      this.dataSource = expenses;
    });
  }
}

