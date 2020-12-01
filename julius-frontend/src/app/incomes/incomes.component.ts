import { Component, OnInit } from '@angular/core';
import {ExpenseItem} from '../expenses/expense-item/expense-item';
import {MatDialog} from '@angular/material/dialog';
import {AlertComponent} from '../alert/alert.component';
import {Income} from './income-item/income';
import {IncomeItemComponent} from './income-item/income-item.component';

@Component({
  selector: 'app-incomes',
  templateUrl: './incomes.component.html',
  styleUrls: ['./incomes.component.css']
})
export class IncomesComponent implements OnInit {

  constructor(public dialog: MatDialog) {}

  displayedColumns: string[] = ['receivingDate', 'description', 'totalValue', 'action'];

  dataSource: Income[] = [
    {receivingDate: 'Dia 10', description: 'Saldo anterior', totalValue: 163.39},
    {receivingDate: 'Dia 10', description: 'Salário', totalValue: 217.60},
    {receivingDate: 'Dia 10', description: 'FGTS Aniversario', totalValue: 79.99}
  ];

  animal: string;
  name: string;

  ngOnInit(): void {
  }

  openFinancialItemDialog(): void {
    const dialogRef = this.dialog.open(IncomeItemComponent, {
      width: '250px',
      data: new ExpenseItem()
    });

    dialogRef.afterClosed().subscribe(result => {
      this.animal = result;
    });
  }

  openAlertDialog(): void {
    this.dialog.open(AlertComponent, {});
  }

  total(): number {
    return this.dataSource.reduce((x, {totalValue}) => x + totalValue, 0);
  }
}
