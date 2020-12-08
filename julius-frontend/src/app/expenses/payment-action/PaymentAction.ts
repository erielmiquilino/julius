export class PaymentAction {
  expenseId: string;
  paymentDate: string;
  paymentValue: number;

  constructor(expenseId: string) {
    this.expenseId = expenseId;
  }
}
