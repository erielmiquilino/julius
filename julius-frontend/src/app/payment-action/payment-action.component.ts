import {Component, Inject} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';
import {PaymentAction} from './PaymentAction';

@Component({
  selector: 'app-payment-action',
  templateUrl: './payment-action.component.html',
  styleUrls: ['./payment-action.component.css']
})
export class PaymentActionComponent {

  constructor(
    public dialogRef: MatDialogRef<PaymentActionComponent>,
    @Inject(MAT_DIALOG_DATA) public data: PaymentAction) {}

  onNoClick(): void {
    this.dialogRef.close();
  }

}
