using ApiClientes.App.Models;
using ApiClientes.App.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientes.App.Repositories.Interfaces
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        Task<IEnumerable<Endereco>> GetClientesEnderecos();
        Task<Endereco> GetClienteEnderecos(int id);
    }
}
