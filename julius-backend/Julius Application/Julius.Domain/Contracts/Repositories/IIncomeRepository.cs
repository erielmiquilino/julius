using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Julius.Domain.Domains;
using Julius.Domain.DTOs;

namespace Julius.Domain.Contracts.Repositories
{
    public interface IIncomeRepository : IBaseRepository<Income>
    {
        Task<IEnumerable<IncomeDto>> SelectByPeriodId(Guid periodId);
    }
}
