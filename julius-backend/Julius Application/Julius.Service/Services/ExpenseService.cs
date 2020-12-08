using AutoMapper;
using Julius.Domain.Contracts.Repositories;
using Julius.Domain.Contracts.Services;
using Julius.Domain.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Julius.Common.Extensions;
using Julius.Domain.Domains;
using Julius.Domain.Enums;

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

        public async Task<IEnumerable<MonthModel>> GetMonthsWithRecords()
        {
            var months = await _repository.GetMonths();

            if (months.Any())
                return _mapper.Map<IEnumerable<MonthModel>>(months);

            var now = DateTime.Now;
            var cultureInfo = new CultureInfo("pt-BR");

            return new List<MonthModel>() {new MonthModel()
            {
                Year = now.Year.ToString(),
                Month = now.ToString("MMMM", cultureInfo).FirstCharToUpper()
            }};
        }

        public async Task<IEnumerable<ExpenseModel>> GetExpensesByMonthAndYear(string month, string year)
        {
            var expenses = await _repository.SelectByMonthAndYear(month, year);

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

        public async Task<Expense> Post(CreateExpenseModel createExpenseModel)
        {
            var expense = _mapper.Map<Expense>(createExpenseModel);

            expense.UpdateExpenseStatus(ExpenseStatus.Opened);

            return await _repository.InsertAsync(expense);
        }
    }
}
