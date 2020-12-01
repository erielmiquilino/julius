import {Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';
import {Income} from './income';

@Component({
  selector: 'app-income-item',
  templateUrl: './income-item.component.html',
  styleUrls: ['./income-item.component.css']
})
export class IncomeItemComponent {

  constructor(
    public dialogRef: MatDialogRef<IncomeItemComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Income) {}

  onNoClick(): void {
    this.dialogRef.close();
  }
}
