using ApiClientes.App.Models;
using ApiClientes.App.Models.DTOs;
using ApiClientes.Test.Mocks.Services;
using ApiClientes.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Xunit;

namespace ApiClientes.Test.Controllers
{
    public class ClienteControllerTests
    {
        [Fact]
        public async void ClienteController_Teste_Entrada_Dados_CPF_Invalido()
        {
            //Arrange
            var mockCliente = new ClienteDTO()
            {
                Id = 1,
                CPF = "687.662.260-68", // inválido
                Nascimento = new DateTime(1980, 10, 30),
                Nome = "Amanda Nunes"
            };

            var mockClienteService = new MockClienteService().MockAdd(mockCliente);

            var controller = new ClientesController(mockClienteService.Object);

            //Act
            ValidacaoModel.SimularValidacao(mockCliente, controller);
            var result = await controller.Post(mockCliente);

            //Assert
            Assert.IsAssignableFrom<BadRequestObjectResult>(result);
        }

        [Fact]
        public async void ClienteController_Teste_Entrada_Dados_CPF_Nao_Preenchido()
        {
            //Arrange
            var mockCliente = new ClienteDTO()
            {
                Id = 1,
                CPF = "", // inválido
                Nascimento = new DateTime(1980, 10, 30),
                Nome = "Amanda Nunes"
            };

            var mockClienteService = new MockClienteService().MockAdd(mockCliente);

            var controller = new ClientesController(mockClienteService.Object);

            //Act
            ValidacaoModel.SimularValidacao(mockCliente, controller);
            var result = await controller.Post(mockCliente);

            //Assert
            Assert.IsAssignableFrom<BadRequestObjectResult>(result);
        }

        [Fact]
        public async void ClienteController_Teste_Entrada_Dados_CPF_Ausente()
        {
            //Arrange
            var mockCliente = new ClienteDTO()
            {
                Id = 1,
                Nascimento = new DateTime(1980, 10, 30),
                Nome = "Amanda Nunes"
            };

            var mockClienteService = new MockClienteService().MockAdd(mockCliente);

            var controller = new ClientesController(mockClienteService.Object);

            //Act
            ValidacaoModel.SimularValidacao(mockCliente, controller);
            var result = await controller.Post(mockCliente);

            //Assert
            Assert.IsAssignableFrom<BadRequestObjectResult>(result);
        }

        [Fact]
        public async void ClienteController_Teste_Entrada_Dados_Nascimento_Invalido()
        {
            //Arrange
            var mockCliente = new ClienteDTO()
            {
                Id = 1,
                CPF = "687.662.260-66",
                Nascimento = new DateTime(1880, 10, 30),// inválido
                Nome = "Amanda Nunes"
            };

            var mockClienteService = new MockClienteService().MockAdd(mockCliente);

            var controller = new ClientesController(mockClienteService.Object);

            //Act
            ValidacaoModel.SimularValidacao(mockCliente, controller);
            var result = await controller.Post(mockCliente);

            //Assert
            Assert.IsAssignableFrom<BadRequestObjectResult>(result);
        }

        [Fact]
        public async void ClienteController_Teste_Entrada_Dados_Nascimento_Ausente()
        {
            //Arrange
            var mockCliente = new ClienteDTO()
            {
                Id = 1,
                CPF = "687.662.260-66",
                Nome = "Amanda Nunes"
            };

            var mockClienteService = new MockClienteService().MockAdd(mockCliente);

            var controller = new ClientesController(mockClienteService.Object);

            //Act
            ValidacaoModel.SimularValidacao(mockCliente, controller);
            var result = await controller.Post(mockCliente);

            //Assert
            Assert.IsAssignableFrom<BadRequestObjectResult>(result);
        }

        [Fact]
        public async void ClienteController_Teste_Entrada_Dados_Nome_Vazio()
        {
            //Arrange
            var mockCliente = new ClienteDTO()
            {
                Id = 1,
                CPF = "687.662.260-66",
                Nascimento = new DateTime(1980, 10, 30),// inválido
                Nome = ""
            };

            var mockClienteService = new MockClienteService().MockAdd(mockCliente);

            var controller = new ClientesController(mockClienteService.Object);

            //Act
            ValidacaoModel.SimularValidacao(mockCliente, controller);
            var result = await controller.Post(mockCliente);

            //Assert
            Assert.IsAssignableFrom<BadRequestObjectResult>(result);
        }

        [Fact]
        public async void ClienteController_Teste_Entrada_Dados_Nome_Grande()
        {
            //Arrange
            var mockCliente = new ClienteDTO()
            {
                Id = 1,
                CPF = "687.662.260-66",
                Nascimento = new DateTime(1980, 10, 30),// inválido
                Nome = "Amanda Nunes 1234567890 1234567890 1234567890 1234567890 1234567890 1234567890 1234567890 1234567890 1234567890 1234567890 1234567890 1234567890"
            };

            var mockClienteService = new MockClienteService().MockAdd(mockCliente);

            var controller = new ClientesController(mockClienteService.Object);

            //Act
            ValidacaoModel.SimularValidacao(mockCliente, controller);
            var result = await controller.Post(mockCliente);

            //Assert
            Assert.IsAssignableFrom<BadRequestObjectResult>(result);
        }

        [Fact]
        public async void ClienteController_get_Valid()
        {
            //Arrange
            var mockCliente = new ClienteDTO()
            {
                Id = 1
            };

            var mockClienteService = new MockClienteService().MockGetByID(mockCliente);

            var controller = new ClientesController(mockClienteService.Object);

            //Act
            var result = await controller.Get(1);

            //Assert
            OkObjectResult okObjectResult = result.Result as OkObjectResult;
            var model = okObjectResult.Value as ClienteDTO;

            Assert.IsAssignableFrom<OkObjectResult>(result.Result);
            Assert.NotNull(okObjectResult);
            Assert.NotNull(model);
        }

        [Fact]
        public async void ClienteController_get_Invalid()
        {
            //Arrange
            var mockClienteService = new MockClienteService().MockGetByIDInvalid();

            var controller = new ClientesController(mockClienteService.Object);

            //Act
            // var result = await controller.Get(1);

            //Assert
            await Assert.ThrowsAsync<Exception>(() => controller.Get(1));
        }

        [Fact]
        public async void ClienteController_getall_Valid()
        {
            //Arrange
            var mockCliente = new List<ClienteDTO>()
            {
                new ClienteDTO() { Id = 1 },
                new ClienteDTO() { Id = 2 },
            };

            var mockClienteService = new MockClienteService().MockGetAll(mockCliente);

            var controller = new ClientesController(mockClienteService.Object);

            //Act
            var result = await controller.Get();

            //Assert
            OkObjectResult okObjectResult = result.Result as OkObjectResult;
            var model = okObjectResult.Value as List<ClienteDTO>;

            Assert.IsAssignableFrom<OkObjectResult>(result.Result);
            Assert.NotNull(okObjectResult);
            Assert.NotNull(model);
        }

        [Fact]
        public async void ClienteController_getall_Invalid()
        {
            //Arrange
            var mockClienteService = new MockClienteService().MockGetAllInvalid();

            var controller = new ClientesController(mockClienteService.Object);

            //Act
            // var result = await controller.Get();

            //Assert
            await Assert.ThrowsAsync<Exception>(() => controller.Get());
        }

        [Fact]
        public async void ClienteController_getall_Vazio()
        {
            //Arrange
            var mockClienteService = new MockClienteService().MockGetAllVazio();

            var controller = new ClientesController(mockClienteService.Object);

            //Act
            var result = await controller.Get();

            //Assert
            OkObjectResult okObjectResult = result.Result as OkObjectResult;
            var model = okObjectResult.Value as List<ClienteDTO>;

            Assert.IsAssignableFrom<OkObjectResult>(result.Result);
            Assert.NotNull(okObjectResult);
            Assert.NotNull(model);
        }

        [Fact]
        public async void ClienteController_add_Valid()
        {
            //Arrange
            var mockCliente = new ClienteDTO()
            {
                Id = 1,
                CPF = "687.662.260-66",
                Nascimento = new DateTime(1980, 10, 30),
                Nome = "Amanda Nunes"
            };

            var mockClienteService = new MockClienteService().MockAdd(mockCliente);

            var controller = new ClientesController(mockClienteService.Object);

            //Act
            ValidacaoModel.SimularValidacao(mockCliente, controller);
            var result = await controller.Post(mockCliente);

            //Assert
            CreatedAtRouteResult okObjectResult = result as CreatedAtRouteResult;

            Assert.IsAssignableFrom<CreatedAtRouteResult>(result);
            Assert.NotNull(okObjectResult);
        }

        [Fact]
        public async System.Threading.Tasks.Task ClienteController_add_InValid()
        {
            //Arrange
            var mockCliente = new ClienteDTO()
            {
                Id = 1,
                CPF = "687.662.260-66",
                Nascimento = new DateTime(1980, 10, 30),
                Nome = "Amanda Nunes"
            };

            var mockClienteService = new MockClienteService().MockAddInvalid(mockCliente);

            var controller = new ClientesController(mockClienteService.Object);

            //Act
            // var result = await controller.Post(mockCliente);

            //Assert
            await Assert.ThrowsAsync<Exception>(() => controller.Post(mockCliente));
        }

        [Fact]
        public async void ClienteController_update_Valid()
        {
            //Arrange
            var mockCliente = new ClienteDTO()
            {
                Id = 1,
                CPF = "687.662.260-66",
                Nascimento = new DateTime(1980, 10, 30),
                Nome = "Amanda Nunes"
            };

            var mockClienteService = new MockClienteService().MockUpdate(mockCliente);

            var controller = new ClientesController(mockClienteService.Object);

            //Act
            var result = await controller.Put(1, mockCliente);

            //Assert
            OkResult okObjectResult = result as OkResult;

            Assert.IsAssignableFrom<OkResult>(result);
            Assert.NotNull(okObjectResult);
        }

        [Fact]
        public async System.Threading.Tasks.Task ClienteController_update_InValid()
        {
            //Arrange
            var mockCliente = new ClienteDTO()
            {
                Id = 1,
                CPF = "687.662.260-66",
                Nascimento = new DateTime(1980, 10, 30),
                Nome = "Amanda Nunes"
            };

            var mockClienteService = new MockClienteService().MockUpdateInvalid(mockCliente);

            var controller = new ClientesController(mockClienteService.Object);

            //Act
            // var result = await controller.Post(mockCliente);

            //Assert
            await Assert.ThrowsAsync<Exception>(() => controller.Put(1, mockCliente));
        }

    }
}
