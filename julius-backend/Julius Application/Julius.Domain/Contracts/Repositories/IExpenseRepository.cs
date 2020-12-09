using System;
using Julius.Domain.Domains;
using System.Collections.Generic;
using System.Threading.Tasks;
using Julius.Domain.DTOs;

namespace Julius.Domain.Contracts.Repositories
{
    public interface IExpenseRepository : IBaseRepository<Expense>
    {
        Task<IEnumerable<MonthDto>> GetMonths();

        Task<IEnumerable<ExpenseDto>> SelectByMonthAndYear(string month, string year);

        Task<Expense> SelectById(Guid expenseId);

        Task<IEnumerable<AmountExpenseDto>> SelectAmountByMonthAndYear(string month, string year);
    }
}
