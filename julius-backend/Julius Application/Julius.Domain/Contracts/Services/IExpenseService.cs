using Julius.Domain.Domains;
using Julius.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Julius.Domain.Contracts.Services
{
    public interface IExpenseService
    {
        Task<IEnumerable<ExpenseModel>> GetExpensesByMonthAndYear(string month, string year);
        
        Task<Expense> Post(CreateExpenseModel createExpenseModel);

        Task<ExpenseModel> Get(Guid id);

        Task SavePaymentAction(PaymentActionModel paymentActionModel);
        
        Task DeleteExpense(Guid id);

        Task<TotalsModel> GetAmountByMonthAndYear(string month, string year);
    }
}
