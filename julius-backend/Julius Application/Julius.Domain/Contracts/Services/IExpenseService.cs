using Julius.Domain.Domains;
using Julius.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Julius.Domain.Contracts.Services
{
    public interface IExpenseService
    {
        Task<Expense> Get(Guid id);

        Task<IEnumerable<ExpenseModel>> GetAll();

        Task<Expense> Post(Expense product);

        Task<Expense> Put(Expense product);

        Task<bool> Delete(Guid id);

        Task<IEnumerable<MonthModel>> GetMonthsWithRecords();
    }
}
