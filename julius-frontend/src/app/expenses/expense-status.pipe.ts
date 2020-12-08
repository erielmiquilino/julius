import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'expenseStatus'
})
export class ExpenseStatusPipe implements PipeTransform {

  private expenseStatus = [
    {
      value: 0,
      description: 'PAGO'
    },
    {
      value: 1,
      description: 'PARCIAL',
    },
    {
      value: 2,
      description: 'EM ABERTO'
    }
  ];

  transform(expenseStatus: number): string {
    return this.expenseStatus.find(x => x.value === expenseStatus).description;
  }

}
