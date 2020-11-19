using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientes.App.Repositories.Base
{
    public interface IRepository<T>
    {
        //Task<IQueryable<T>> Query();
        IQueryable<T> Query2();
        Task<IEnumerable<T>> Get();
        Task<T> Get(Expression<Func<T, bool>> predicate);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);

    }
}
