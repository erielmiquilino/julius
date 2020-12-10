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
    public class IncomeRepository : BaseRepository<Income>, IIncomeRepository
    {
        private readonly DbSet<Income> _dbSet;
        private readonly IMapper _mapper;

        public IncomeRepository(JuliusContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
            _dbSet = context.Set<Income>();
        }

        public async Task<IEnumerable<IncomeDto>> SelectByMonthAndYear(string month, string year)
        {
            var queryableIncomes = _dbSet.Where(x => x.Month == month && x.Year == year)
                .OrderBy(x => x.InsertDateTime);

            return await _mapper.ProjectTo<IncomeDto>(queryableIncomes)
                .ToListAsync();
        }
    }
}
