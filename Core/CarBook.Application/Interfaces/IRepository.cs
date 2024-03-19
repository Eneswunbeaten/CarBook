using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces
{
    public interface IRepository<T>where T:class
    {
        public Task<List<T>> GetAllAsync();
        public Task<T> GetByIdAsync(int id);
        public Task CreateAsync(T entity);
        public Task UpdateAsync(T entity);
        public Task RemoveAsync(T entity);
        public Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter);
    }
}
