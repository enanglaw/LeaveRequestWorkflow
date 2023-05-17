using LeaveRequest.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveRequest.Persistence.Repositories
{
    public class BaseAsyncRepository<T> : IBaseAsyncRepository<T> where T : class
    {
        private readonly LeaveRequestDbContext _context;
        private DbSet<T>? employeeTable = null;
        public BaseAsyncRepository(LeaveRequestDbContext context)
        {
            _context = context;
            employeeTable = _context.Set<T>();
        }
        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
           // _context.Set<T>().Remove(entity);
            _context.Set<T>().Entry(entity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            
        }

        public async Task<T> GetByIdAsync(int id)
        {
         T? t=await _context.Set<T>().FindAsync(id);

            return t;
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {

            
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
