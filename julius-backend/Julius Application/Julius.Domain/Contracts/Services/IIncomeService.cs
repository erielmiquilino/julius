using System.Collections.Generic;
using System.Threading.Tasks;
using Julius.Domain.Models;

namespace Julius.Domain.Contracts.Services
{
    public interface IIncomeService
    {
        Task<IEnumerable<IncomeModel>> GetIncomesByMonthAndYear(string month, string year);
    }
}
