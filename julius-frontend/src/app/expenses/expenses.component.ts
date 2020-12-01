import { Component, OnInit } from '@angular/core';
import {MatDialog} from '@angular/material/dialog';
import {ExpenseItem} from './expense-item/expense-item';
import {ExpenseItemComponent} from './expense-item/expense-item.component';
import {PaymentActionComponent} from '../payment-action/payment-action.component';
import {PaymentAction} from '../payment-action/PaymentAction';
import {AlertComponent} from '../alert/alert.component';

@Component({
  selector: 'app-expenses',
  templateUrl: './expenses.component.html',
  styleUrls: ['./expenses.component.css']
})
export class ExpensesComponent implements OnInit {

  constructor(public dialog: MatDialog) {}

  displayedColumns: string[] = ['billingDate', 'description', 'totalValue', 'totalPaid', 'status', 'action'];

  totalIncome = 50000;

  dataSource: ExpenseItem[] = [
    {billingDate: 'Dia 10', description: 'Emprestimo Banco da Familia', totalValue: 163.39, totalPaid: 163.39, status: 'PAGO'},
    {billingDate: 'Dia 10', description: 'Emprestimo Ailos (21/36)', totalValue: 217.60, totalPaid: 217.60, status: 'PAGO'},
    {billingDate: 'Dia 10', description: 'Emprestimo Ailos (21/36)', totalValue: 217.60, totalPaid: 217.60, status: 'PAGO'},
    {billingDate: 'Dia 10', description: 'Emprestimo Ailos (21/36)', totalValue: 217.60, totalPaid: 217.60, status: 'PAGO'},
    {billingDate: 'Dia 10', description: 'Emprestimo Ailos (21/36)', totalValue: 217.60, totalPaid: 217.60, status: 'PAGO'},
    {billingDate: 'Dia 10', description: 'Emprestimo Ailos (21/36)', totalValue: 217.60, totalPaid: 217.60, status: 'PAGO'},
    {billingDate: 'Dia 10', description: 'Emprestimo Ailos (21/36)', totalValue: 217.60, totalPaid: 217.60, status: 'PAGO'},
    {billingDate: 'Dia 10', description: 'Emprestimo Ailos (21/36)', totalValue: 217.60, totalPaid: 217.60, status: 'PAGO'},
    {billingDate: 'Dia 10', description: 'Emprestimo Ailos (21/36)', totalValue: 217.60, totalPaid: 217.60, status: 'PAGO'},
    {billingDate: 'Dia 10', description: 'Emprestimo Ailos (21/36)', totalValue: 217.60, totalPaid: 217.60, status: 'PAGO'},
    {billingDate: 'Dia 10', description: 'Emprestimo Ailos (21/36)', totalValue: 217.60, totalPaid: 217.60, status: 'PAGO'},
    {billingDate: 'Dia 10', description: 'Emprestimo Ailos (21/36)', totalValue: 217.60, totalPaid: 217.60, status: 'PAGO'},
    {billingDate: 'Dia 10', description: 'Emprestimo Ailos (21/36)', totalValue: 217.60, totalPaid: 217.60, status: 'PAGO'},
    {billingDate: 'Dia 10', description: 'Emprestimo Ailos (21/36)', totalValue: 217.60, totalPaid: 217.60, status: 'PAGO'},
    {billingDate: 'Dia 10', description: 'Emprestimo Ailos (21/36)', totalValue: 217.60, totalPaid: 217.60, status: 'PAGO'},
    {billingDate: 'Dia 10', description: 'Emprestimo Ailos (21/36)', totalValue: 217.60, totalPaid: 217.60, status: 'PAGO'},
    {billingDate: 'Dia 10', description: 'Emprestimo Ailos (21/36)', totalValue: 217.60, totalPaid: 217.60, status: 'PAGO'},
    {billingDate: 'Dia 10', description: 'Emprestimo Ailos (21/36)', totalValue: 217.60, totalPaid: 217.60, status: 'PAGO'},
    {billingDate: 'Dia 10', description: 'Emprestimo Ailos (21/36)', totalValue: 217.60, totalPaid: 217.60, status: 'PAGO'},
    {billingDate: 'Dia 10', description: 'Emprestimo Ailos (21/36)', totalValue: 217.60, totalPaid: 217.60, status: 'PAGO'},
    {billingDate: 'Dia 10', description: 'Emprestimo Ailos (21/36)', totalValue: 217.60, totalPaid: 217.60, status: 'PAGO'},
    {billingDate: 'Dia 10', description: 'Emprestimo Ailos (21/36)', totalValue: 217.60, totalPaid: 217.60, status: 'PAGO'},
    {billingDate: 'Dia 10', description: 'Emprestimo Ailos (21/36)', totalValue: 217.60, totalPaid: 217.60, status: 'PAGO'},
    {billingDate: 'Dia 10', description: 'Emprestimo Ailos (21/36)', totalValue: 217.60, totalPaid: 217.60, status: 'PAGO'},
    {billingDate: 'Dia 10', description: 'Emprestimo Ailos (21/36)', totalValue: 217.60, totalPaid: 217.60, status: 'PAGO'},
    {billingDate: 'Dia 10', description: 'Internet Claro Fixo', totalValue: 79.99, totalPaid: 79.99, status: 'PENDENTE'}
  ];

  animal: string;
  name: string;

  ngOnInit(): void {
  }

  openFinancialItemDialog(): void {
    const dialogRef = this.dialog.open(ExpenseItemComponent, {
      width: '250px',
      data: new ExpenseItem()
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      this.animal = result;
    });
  }

  openPaymentActionDialog(): void {
    const dialogRef = this.dialog.open(PaymentActionComponent, {
      width: '250px',
      data: new PaymentAction()
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      this.animal = result;
    });
  }

  openAlertDialog(): void {
    this.dialog.open(AlertComponent, {});
  }

  spendingForecast(): number {
    return this.dataSource.reduce((x, {totalValue}) => x + totalValue, 0);
  }

  totalPaid(): number {
    return this.dataSource.reduce((x, {totalPaid}) => x + totalPaid, 0);
  }
}
