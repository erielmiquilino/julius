using Julius.Data.Context;
using Julius.Data.Repositories.Base;
using Julius.Domain.Contracts.Repositories;
using Julius.Domain.Domains;

namespace Julius.Data.Repositories
{
    public class PeriodRepository : BaseRepository<Period>, IPeriodRepository
    {
        public PeriodRepository(JuliusContext context) : base(context)
        {
        }
    }
}
