using CarBook.Application.Interfaces;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly CarbookContext _context;

        public Repository(CarbookContext context)
        {
            _context = context;
        }

        async Task IRepository<T>.CreateAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        async Task<List<T>> IRepository<T>.GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        async Task<T> IRepository<T>.GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        async Task IRepository<T>.RemoveAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        async Task IRepository<T>.UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
