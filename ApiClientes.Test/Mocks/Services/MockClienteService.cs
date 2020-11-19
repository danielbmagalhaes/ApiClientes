using ApiClientes.App.Models.DTOs;
using ApiClientes.App.Services.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiClientes.Test.Mocks.Services
{
    public class MockClienteService : Mock<IClienteService>
    {
        public MockClienteService MockGetByID(ClienteDTO result)
        {
            Setup(x => x.Get(It.IsAny<int>()))
                .ReturnsAsync(result);

            return this;
        }

        public MockClienteService MockGetByIDInvalid()
        {
            Setup(x => x.Get(It.IsAny<int>()))
                .Throws(new Exception("Cliente não encontrado!"));

            return this;
        }

        public MockClienteService MockGetAll(List<ClienteDTO> result)
        {
            Setup(x => x.GetAll())
                .ReturnsAsync(result);

            return this;
        }

        public MockClienteService MockGetAllInvalid()
        {
            Setup(x => x.GetAll())
                .Throws(new Exception("Erro!"));

            return this;
        }

        public MockClienteService MockGetAllVazio()
        {
            Setup(x => x.GetAll())
                .ReturnsAsync(new List<ClienteDTO>());

            return this;
        }

        public MockClienteService MockAdd(ClienteDTO result)
        {
            Setup(x => x.Add(It.IsAny<ClienteDTO>()))
                .ReturnsAsync(result);

            return this;
        }

        public MockClienteService MockAddInvalid(ClienteDTO result)
        {
            Setup(x => x.Add(It.IsAny<ClienteDTO>())).Throws(new Exception("Erro!"));

            return this;
        }

        public MockClienteService MockUpdate(ClienteDTO result)
        {
            Setup(x => x.Update(It.IsAny<ClienteDTO>()));
            Setup(x => x.Get(It.IsAny<int>()))
                .ReturnsAsync(result);

            return this;
        }

        public MockClienteService MockUpdateInvalid(ClienteDTO result)
        {
            Setup(x => x.Update(It.IsAny<ClienteDTO>())).Throws(new Exception("Erro!"));
            Setup(x => x.Get(It.IsAny<int>()))
                .ReturnsAsync(result);

            return this;
        }

    }
}
