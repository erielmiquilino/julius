using Julius.Domain.Domains;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Julius.Domain.Models;

namespace Julius.Domain.Contracts.Services
{
    public interface IExpenseService
    {
        Task<Expense> Get(Guid id);

        Task<IEnumerable<ExpenseModel>> GetAll();

        Task<Expense> Post(Expense product);

        Task<Expense> Put(Expense product);

        Task<bool> Delete(Guid id);

        Task<MonthModel> GetMonthsWithRecords();
    }
}
