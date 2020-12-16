import {Component, Inject} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';
import {Expense} from './expense';
import {MAT_DATE_FORMATS} from '@angular/material/core';

export const FORMATS = {
  parse: {
    dateInput: 'DD',
  },
  display: {
    dateInput: 'DD',
    monthYearLabel: 'MMM YYYY',
    dateA11yLabel: 'LL',
    monthYearA11yLabel: 'MMMM YYYY',
  },
};

@Component({
  selector: 'app-expense-item',
  templateUrl: './expense-item.component.html',
  styleUrls: ['./expense-item.component.css'],
  providers: [
    {provide: MAT_DATE_FORMATS, useValue: FORMATS},
  ]
})
export class ExpenseItemComponent  {

  constructor(
    public dialogRef: MatDialogRef<ExpenseItemComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Expense) {}

  onNoClick(): void {
    this.dialogRef.close();
  }

}
