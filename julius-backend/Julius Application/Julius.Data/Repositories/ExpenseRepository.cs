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
    }
}
