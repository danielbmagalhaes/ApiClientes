using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientes.App.Services.Interfaces
{
    public interface IServiceBase<T>
    {
        Task<T> Get(int id);
        Task<List<T>> GetAll();
        Task<T> Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
