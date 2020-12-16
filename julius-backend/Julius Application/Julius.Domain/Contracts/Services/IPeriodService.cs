using Julius.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Julius.Domain.Contracts.Services
{
    public interface IPeriodService
    {
        Task<IEnumerable<PeriodModel>> GetPeriodsWithRecords();
    }
}
