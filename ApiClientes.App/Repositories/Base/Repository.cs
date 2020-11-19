using ApiClientes.App.Models.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientes.App.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected ApiClientesDbContext _context;

        public Repository(ApiClientesDbContext context)
        {
            _context = context;
        }

        public IQueryable<T> Query2()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public async Task<IEnumerable<T>> Get()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> Get(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(predicate);
        }

        public async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public Task Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            return _context.SaveChangesAsync();
        }

        public Task Update(T entity)
        {

            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }
        
    }
}
