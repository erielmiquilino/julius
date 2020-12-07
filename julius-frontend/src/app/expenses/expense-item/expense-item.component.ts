import {Component, Inject} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';
import {ExpenseItem} from './expense-item';
import {DateAdapter, MAT_DATE_FORMATS, NativeDateAdapter} from '@angular/material/core';
import * as moment from 'moment';

export class AppDateAdapter extends NativeDateAdapter {
  format(date: Date, displayFormat: any): string {
    return moment(date).format('DD');
  }
}

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
    {provide: DateAdapter, useClass: AppDateAdapter},
    {provide: MAT_DATE_FORMATS, useValue: FORMATS},
  ]
})
export class ExpenseItemComponent  {

  constructor(
    public dialogRef: MatDialogRef<ExpenseItemComponent>,
    @Inject(MAT_DIALOG_DATA) public data: ExpenseItem) {}

  onNoClick(): void {
    this.dialogRef.close();
  }

}
