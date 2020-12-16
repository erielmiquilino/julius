using AutoMapper;
using Julius.Domain.Contracts.Repositories;
using Julius.Domain.Contracts.Services;
using Julius.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Julius.Service.Services
{
    public class PeriodService : IPeriodService
    {
        private readonly IPeriodRepository _repository;
        private readonly IMapper _mapper;

        public PeriodService(IPeriodRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PeriodModel>> GetPeriodsWithRecords()
        {
            var periods = await _repository.SelectAsync();

            return _mapper.Map<IEnumerable<PeriodModel>>(periods);
        }
    }
}
