using AutoMapper;
using Julius.Common.Extensions;
using Julius.Domain.Contracts.Repositories;
using Julius.Domain.Contracts.Services;
using Julius.Domain.Domains;
using Julius.Domain.Enums;
using Julius.Domain.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Julius.Service.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _repository;
        private readonly IMapper _mapper;

        public ExpenseService(IExpenseRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ExpenseModel>> GetExpensesByPeriodId(Guid periodId)
        {
            var expenses = await _repository.SelectByPeriodId(periodId);

            return _mapper.Map<IEnumerable<ExpenseModel>>(expenses);
        }

        public async Task<ExpenseModel> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);

            return _mapper.Map<ExpenseModel>(entity);
        }

        public async Task SavePaymentAction(PaymentActionModel paymentActionModel)
        {
            var expense = await _repository.SelectById(paymentActionModel.ExpenseId);

            expense.UpdateByPaymentAction(paymentActionModel);

            await _repository.UpdateAsync(expense);
        }

        public async Task DeleteExpense(Guid id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<TotalsModel> GetAmountByPeriodId(Guid periodId)
        {
            var amountExpenses = await _repository.SelectAmountByPeriodId(periodId);
            var amountExpensesList = amountExpenses.ToList();

            const decimal totalIncome = 3579.17M;
            var totalPaid = amountExpensesList.Sum(x => x.TotalPaid);
            var spendingForecast = amountExpensesList.Sum(x => x.TotalValue);
            return new TotalsModel()
            {
                TotalPaid = totalPaid,
                SpendingForecast = spendingForecast,
                CurrentInAccounts = totalIncome - totalPaid,
                TotalIncome = totalIncome,
                TotalAvailable = totalIncome - spendingForecast
            };
        }

        public async Task<Expense> Post(CreateExpenseModel createExpenseModel)
        {
            var expense = _mapper.Map<Expense>(createExpenseModel);

            expense.UpdateExpenseStatus(ExpenseStatus.Opened);

            return await _repository.InsertAsync(expense);
        }
    }
}
