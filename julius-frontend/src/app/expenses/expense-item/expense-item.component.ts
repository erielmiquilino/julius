import {Component, Inject} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';
import {ExpenseItem} from './expense-item';

@Component({
  selector: 'app-expense-item',
  templateUrl: './expense-item.component.html',
  styleUrls: ['./expense-item.component.css']
})
export class ExpenseItemComponent  {

  constructor(
    public dialogRef: MatDialogRef<ExpenseItemComponent>,
    @Inject(MAT_DIALOG_DATA) public data: ExpenseItem) {}

  onNoClick(): void {
    this.dialogRef.close();
  }

}
