using ApiClientes.App.Models.DTOs;
using ApiClientes.App.Repositories.Interfaces;
using ApiClientes.App.Services.Interfaces;
using System.Collections.Generic;
using AutoMapper;
using ApiClientes.App.Models;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace ApiClientes.App.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _ClienteRepository;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepository ClienteRepository, IMapper mapper)
        {
            _ClienteRepository = ClienteRepository;
            _mapper = mapper;
        }

        public async Task<ClienteDTO> Add(ClienteDTO entity)
        {
            var cliente = _mapper.Map<Cliente>(entity);
            cliente.Id = 0;
            cliente.CreatedAt = DateTime.Now;
            cliente.UpdatedAt = DateTime.Now;

            await _ClienteRepository.Add(cliente);

            return _mapper.Map<ClienteDTO>(cliente);
        }

        public async Task Delete(ClienteDTO entity)
        {
            var clienteEncontrado = await _ClienteRepository.Get(c => c.Id == entity.Id);

            if (clienteEncontrado == null) throw new System.Exception("Erro ao localizar o cliente");

            await _ClienteRepository.Delete(clienteEncontrado);
        }

        public async Task<ClienteDTO> Get(int id)
        {
            // var cliente = await _ClienteRepository.Get(c => c.Id == id);
            var cliente = await _ClienteRepository.GetEnderecosCliente(id);

            if (cliente == null) return null;  //throw new System.Exception("Erro ao localizar o cliente");

            return _mapper.Map<ClienteDTO>(cliente);
        }

        public async Task<List<ClienteDTO>> GetAll()
        {
            var clientes = await _ClienteRepository.GetEnderecosClientes();
            var clientesDTO = _mapper.Map<List<ClienteDTO>>(clientes);
            return clientesDTO;
        }

        public async Task Update(ClienteDTO entity)
        {
            var clienteEncotrado = await _ClienteRepository.Get(c => c.Id == entity.Id);

            if (clienteEncotrado == null) throw new System.Exception("Erro ao localizar o cliente");

            var cliente = _mapper.Map<Cliente>(entity);
            cliente.CreatedAt = clienteEncotrado.CreatedAt;
            cliente.UpdatedAt = DateTime.Now;

            await _ClienteRepository.Update(cliente);
        }
    }
}
