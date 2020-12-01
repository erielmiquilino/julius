import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {CreditCardComponent} from './credit-card/credit-card.component';
import {ExpensesComponent} from './expenses/expenses.component';
import {IncomesComponent} from './incomes/incomes.component';

const routes: Routes = [
  {path: 'credit-card', component: CreditCardComponent},
  {path: 'expenses', component: ExpensesComponent},
  {path: 'incomes', component: IncomesComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
