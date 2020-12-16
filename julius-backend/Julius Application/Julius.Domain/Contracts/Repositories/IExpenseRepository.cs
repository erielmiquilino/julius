using System;
using Julius.Domain.Domains;
using System.Collections.Generic;
using System.Threading.Tasks;
using Julius.Domain.DTOs;

namespace Julius.Domain.Contracts.Repositories
{
    public interface IExpenseRepository : IBaseRepository<Expense>
    {
        Task<IEnumerable<ExpenseDto>> SelectByPeriodId(Guid periodId);

        Task<Expense> SelectById(Guid expenseId);

        Task<IEnumerable<AmountExpenseDto>> SelectAmountByPeriodId(Guid periodId);
    }
}
