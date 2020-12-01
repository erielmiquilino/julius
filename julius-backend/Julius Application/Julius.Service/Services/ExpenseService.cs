using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Julius.Domain.Contracts.Repositories;
using Julius.Domain.Contracts.Services;
using Julius.Domain.Domains;
using Julius.Domain.Models;

namespace Julius.Service.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IBaseRepository<Expense> _repository;
        private readonly IMapper _mapper;

        public ExpenseService(IBaseRepository<Expense> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Expense> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<ExpenseModel>> GetAll()
        {
            var expenses = await _repository.SelectAsync();

            return _mapper.Map<IEnumerable<ExpenseModel>>(expenses);
        }

        public async Task<Expense> Post(Expense product)
        {
            return await _repository.InsertAsync(product);
        }

        public async Task<Expense> Put(Expense product)
        {
            return await _repository.UpdateAsync(product);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<MonthModel> GetMonthsWithRecords()
        {

            throw new NotImplementedException();
        }
    }
}
