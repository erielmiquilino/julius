using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Julius.Domain.Domains.Base;
using Julius.Domain.Models;

namespace Julius.Domain.Contracts.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> InsertAsync(T item);

        Task<T> UpdateAsync(T item);

        Task<bool> DeleteAsync(Guid id);

        Task<T> SelectAsync(Guid id);

        Task<IEnumerable<T>> SelectAsync();

        Task<bool> ExistAsync(Guid id);
    }
}
