using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Julius.Data.Context;
using Julius.Domain.Contracts.Repositories;
using Julius.Domain.Domains.Base;
using Microsoft.EntityFrameworkCore;

namespace Julius.Data.Repositories.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly JuliusContext _context;
        private readonly DbSet<T> _dataSet;

        public BaseRepository(JuliusContext context)
        {
            _context = context;
            _dataSet = _context.Set<T>();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = await _dataSet.SingleOrDefaultAsync(p => p.Id.Equals(id));

            if (result == null)
                return false;

            _dataSet.Remove(result);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ExistAsync(Guid id)
        {
            return await _dataSet.AnyAsync(p => p.Id.Equals(id));
        }

        public async Task<T> InsertAsync(T item)
        {
            if (item.Id == Guid.Empty)
                item.Id = Guid.NewGuid();

            item.InsertDateTime = DateTime.UtcNow;
            await _dataSet.AddAsync(item);

            await _context.SaveChangesAsync();

            return item;
        }

        public async Task<T> SelectAsync(Guid id)
        {
            return await _dataSet.SingleOrDefaultAsync(p => p.Id.Equals(id));
        }

        public async Task<IEnumerable<T>> SelectAsync()
        {
            return await _dataSet.ToListAsync();
        }

        public async Task<T> UpdateAsync(T item)
        {
            var result = await _dataSet.SingleOrDefaultAsync(p => p.Id.Equals(item.Id));

            if (result == null)
                return null;

            item.InsertDateTime = result.InsertDateTime;

            _context.Entry(result).CurrentValues.SetValues(item);
            await _context.SaveChangesAsync();

            return item;
        }
    }
}
