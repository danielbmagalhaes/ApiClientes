using ApiClientes.App.Services.Interfaces;
using System.Collections.Generic;
using AutoMapper;
using System.Threading.Tasks;
using System;
using ApiClientes.App.Repositories.Interfaces;
using ApiClientes.App.Models.DTOs;
using ApiClientes.App.Models;

namespace ApiClientes.App.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _EnderecoRepository;
        private readonly IMapper _mapper;

        public EnderecoService(IEnderecoRepository EnderecoRepository, IMapper mapper)
        {
            _EnderecoRepository = EnderecoRepository;
            _mapper = mapper;
        }

        public async Task<EnderecoDTO> Add(EnderecoDTO entity)
        {
            var endereco = _mapper.Map<Endereco>(entity);
            endereco.Id = 0;
            endereco.CreatedAt = DateTime.Now;
            endereco.UpdatedAt = DateTime.Now;
            endereco.ClienteId = entity.Cliente != null ? entity.Cliente.Id : entity.ClienteId;
            endereco.Cliente = null; // necessário se não o EF tenta inserir na tabela cliente

            await _EnderecoRepository.Add(endereco);

            return _mapper.Map<EnderecoDTO>(endereco);
        }

        public async Task Delete(EnderecoDTO entity)
        {
            var enderecoEncontrado = await _EnderecoRepository.Get(c => c.Id == entity.Id);

            if (enderecoEncontrado == null) throw new System.Exception("Erro ao localizar o Endereco");

            await _EnderecoRepository.Delete(enderecoEncontrado);
        }

        public async Task<EnderecoDTO> Get(int id)
        {
            var Endereco = await _EnderecoRepository.GetClienteEnderecos(id);

            if (Endereco == null) return null;  //throw new System.Exception("Erro ao localizar o Endereco");

            return _mapper.Map<EnderecoDTO>(Endereco);
        }

        public async Task<List<EnderecoDTO>> GetAll()
        {
            var enderecos = await _EnderecoRepository.GetClientesEnderecos();
            var EederecosDTO = _mapper.Map<List<EnderecoDTO>>(enderecos);
            return EederecosDTO;
        }

        public async Task Update(EnderecoDTO entity)
        {
            var EnderecoEncotrado = await _EnderecoRepository.Get(c => c.Id == entity.Id);

            if (EnderecoEncotrado == null) throw new System.Exception("Erro ao localizar o Endereco");

            var Endereco = _mapper.Map<Endereco>(entity);
            Endereco.CreatedAt = EnderecoEncotrado.CreatedAt;
            Endereco.UpdatedAt = DateTime.Now;

            await _EnderecoRepository.Update(Endereco);
        }
    }
}
