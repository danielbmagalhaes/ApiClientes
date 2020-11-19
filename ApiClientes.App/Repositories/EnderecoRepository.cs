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
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(ApiClientesDbContext contexto) : base(contexto)
        {
            
        }
        public async Task<IEnumerable<Endereco>> GetClientesEnderecos()
        {
            return await _context.Set<Endereco>().AsNoTracking().Include("Cliente").ToListAsync();
        }

        public async Task<Endereco> GetClienteEnderecos(int id)
        {
            return await _context.Set<Endereco>().AsNoTracking().Include("Cliente").FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
