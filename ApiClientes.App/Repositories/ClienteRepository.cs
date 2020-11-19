using ApiClientes.App.Models;
using ApiClientes.App.Models.Base;
using ApiClientes.App.Repositories.Base;
using ApiClientes.App.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientes.App.Repositories
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ApiClientesDbContext contexto) : base(contexto)
        {
        }

        public async Task<IEnumerable<Cliente>> GetEnderecosClientes()
        {
            return await _context.Set<Cliente>().AsNoTracking().Include(x => x.Enderecos).ToListAsync();
        }

        public async Task<Cliente> GetEnderecosCliente(int id)
        {
            return await _context.Set<Cliente>().AsNoTracking().Include(x => x.Enderecos).FirstOrDefaultAsync(x=>x.Id == id);
        }
    }
}
