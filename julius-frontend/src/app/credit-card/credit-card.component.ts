import { Component, OnInit } from '@angular/core';
import {MatDialog} from '@angular/material/dialog';
import {PaymentActionComponent} from '../expenses/payment-action/payment-action.component';
import {PaymentAction} from '../expenses/payment-action/PaymentAction';
import {AlertComponent} from '../alert/alert.component';
import {CreditCard} from './credit-card-item/credit-card';
import {CreditCardItemComponent} from './credit-card-item/credit-card-item.component';

@Component({
  selector: 'app-credit-card',
  templateUrl: './credit-card.component.html',
  styleUrls: ['./credit-card.component.css']
})
export class CreditCardComponent implements OnInit {

  constructor(public dialog: MatDialog) {}

  displayedColumns: string[] = ['date', 'description', 'totalValue', 'action'];

  dataSource: CreditCard[] = [
    {date: 'Dia 10', description: 'Amazon Prime', totalValue: 163.39, comments: ''},
    {date: 'Dia 10', description: 'Netflix', totalValue: 217.60, comments: ''},
    {date: 'Dia 10', description: 'Compras Miguel ', totalValue: 79.99, comments: ''}
  ];

  animal: string;
  name: string;

  ngOnInit(): void {
  }

  openCreditCardItemDialog(): void {
    const dialogRef = this.dialog.open(CreditCardItemComponent, {
      width: '250px',
      data: new CreditCard()
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

  total(): number {
    return this.dataSource.reduce((x, {totalValue}) => x + totalValue, 0 );
  }
}
