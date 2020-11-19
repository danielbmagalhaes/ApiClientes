using ApiClientes.App.Models.DTOs;
using ApiClientes.App.Services.Interfaces;
using Moq;
using System;
using System.Collections.Generic;

namespace ApiEnderecos.Test.Mocks.Services
{
    public class MockEnderecoService : Mock<IEnderecoService>
    {
        public MockEnderecoService MockGetByID(EnderecoDTO result)
        {
            Setup(x => x.Get(It.IsAny<int>()))
                .ReturnsAsync(result);

            return this;
        }

        public MockEnderecoService MockGetByIDInvalid()
        {
            Setup(x => x.Get(It.IsAny<int>()))
                .Throws(new Exception("Endereco não encontrado!"));

            return this;
        }

        public MockEnderecoService MockGetAll(List<EnderecoDTO> result)
        {
            Setup(x => x.GetAll())
                .ReturnsAsync(result);

            return this;
        }

        public MockEnderecoService MockGetAllInvalid()
        {
            Setup(x => x.GetAll())
                .Throws(new Exception("Erro!"));

            return this;
        }

        public MockEnderecoService MockGetAllVazio()
        {
            Setup(x => x.GetAll())
                .ReturnsAsync(new List<EnderecoDTO>());

            return this;
        }

        public MockEnderecoService MockAdd(EnderecoDTO result)
        {
            Setup(x => x.Add(It.IsAny<EnderecoDTO>()))
                .ReturnsAsync(result);
            Setup(x => x.Get(It.IsAny<int>()))
                .ReturnsAsync(result);

            return this;
        }

        public MockEnderecoService MockAddInvalid(EnderecoDTO result)
        {
            Setup(x => x.Add(It.IsAny<EnderecoDTO>())).Throws(new Exception("Erro!"));

            return this;
        }

        public MockEnderecoService MockUpdate(EnderecoDTO result)
        {
            Setup(x => x.Update(It.IsAny<EnderecoDTO>()));
            Setup(x => x.Get(It.IsAny<int>()))
                .ReturnsAsync(result);

            return this;
        }

        public MockEnderecoService MockUpdateInvalid(EnderecoDTO result)
        {
            Setup(x => x.Update(It.IsAny<EnderecoDTO>())).Throws(new Exception("Erro!"));
            Setup(x => x.Get(It.IsAny<int>()))
                .ReturnsAsync(result);

            return this;
        }

    }
}
