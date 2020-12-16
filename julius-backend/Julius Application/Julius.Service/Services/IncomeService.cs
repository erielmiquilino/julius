using System;
using AutoMapper;
using Julius.Domain.Contracts.Repositories;
using Julius.Domain.Contracts.Services;
using Julius.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Julius.Service.Services
{
    public class IncomeService : IIncomeService
    {
        private readonly IIncomeRepository _repository;
        private readonly IMapper _mapper;

        public IncomeService(IIncomeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<IncomeModel>> GetIncomesByPeriodId(Guid periodId)
        {
            var incomes = await _repository.SelectByPeriodId(periodId);

            return _mapper.Map<IEnumerable<IncomeModel>>(incomes);
        }
    }
}
