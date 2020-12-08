using System;
using AutoMapper;
using Julius.Data.Context;
using Julius.Data.Repositories.Base;
using Julius.Domain.Contracts.Repositories;
using Julius.Domain.Domains;
using Julius.Domain.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Julius.Data.Repositories
{
    public class ExpenseRepository : BaseRepository<Expense>, IExpenseRepository
    {
        private readonly DbSet<Expense> _dbSet;
        private readonly IMapper _mapper;

        public ExpenseRepository(JuliusContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
            _dbSet = context.Set<Expense>();
        }

        public async Task<IEnumerable<MonthDto>> GetMonths()
        {
            return await _mapper.ProjectTo<MonthDto>(_dbSet)
                .Distinct()
                .ToListAsync();
        }

        public async Task<IEnumerable<ExpenseDto>> SelectByMonthAndYear(string month, string year)
        {
            var queryableExpenses = _dbSet.Where(x => x.Month == month && x.Year == year);

            return await _mapper.ProjectTo<ExpenseDto>(queryableExpenses)
                .ToListAsync();
        }

        public async Task<Expense> SelectById(Guid expenseId)
        {
            return await _dbSet.FirstAsync(x => x.Id == expenseId);
        }
    }
}
