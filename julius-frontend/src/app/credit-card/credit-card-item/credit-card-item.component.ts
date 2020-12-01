import {Component, Inject} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';
import {CreditCard} from './credit-card';

@Component({
  selector: 'app-credit-card-item',
  templateUrl: './credit-card-item.component.html',
  styleUrls: ['./credit-card-item.component.css']
})
export class CreditCardItemComponent {

  constructor(
    public dialogRef: MatDialogRef<CreditCardItemComponent>,
    @Inject(MAT_DIALOG_DATA) public data: CreditCard) {}

  onNoClick(): void {
    this.dialogRef.close();
  }

}
