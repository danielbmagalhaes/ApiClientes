using ApiClientes.App.Models.DTOs;
using ApiClientes.Test;
using ApiClientes.Test.Mocks.Services;
using ApiClientes.Web.Controllers;
using ApiEnderecos.Test.Mocks.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Xunit;

namespace ApiEnderecos.Test.Controllers
{
    public class EnderecoControllerTests
    {
        [Fact]
        public async System.Threading.Tasks.Task EnderecoController_Teste_Entrada_Dados_Cliente_Invalido()
        {
            //Arrange
            var mockEndereco = new EnderecoDTO()
            {
                Id = 1,
                Logradouro = "Rua tal",
                Bairro = "Tio Juca",
                Cidade = "Rio De Jardeiro",
                Estado = "Rio de Fevereiro",
                ClienteId = 0
            };

            var mockEnderecoService = new MockEnderecoService().MockAddInvalid(mockEndereco);
            var mockClienteService = new MockClienteService().MockGetByID(new ClienteDTO());

            var controller = new EnderecosController(mockEnderecoService.Object, mockClienteService.Object);

            ValidacaoModel.SimularValidacaoEndereco(mockEndereco, controller);
            var result = await controller.Post(mockEndereco);

            //Assert
            Assert.IsAssignableFrom<BadRequestObjectResult>(result);
        }

        [Fact]
        public async System.Threading.Tasks.Task EnderecoController_Teste_Entrada_Dados_Cliente_Ausente()
        {
            //Arrange
            var mockEndereco = new EnderecoDTO()
            {
                Id = 1,
                Logradouro = "Rua tal",
                Bairro = "Tio Juca",
                Cidade = "Rio De Jardeiro",
                Estado = "Rio de Fevereiro",
            };

            var mockEnderecoService = new MockEnderecoService().MockAddInvalid(mockEndereco);
            var mockClienteService = new MockClienteService().MockGetByID(new ClienteDTO());

            var controller = new EnderecosController(mockEnderecoService.Object, mockClienteService.Object);

            ValidacaoModel.SimularValidacaoEndereco(mockEndereco, controller);
            var result = await controller.Post(mockEndereco);

            //Assert
            Assert.IsAssignableFrom<BadRequestObjectResult>(result);
        }

        [Fact]
        public async void EnderecoController_get_Valid()
        {
            //Arrange
            var mockEndereco = new EnderecoDTO()
            {
                Id = 1
            };

            var mockEnderecoService = new MockEnderecoService().MockGetByID(mockEndereco);
            var mockClienteService = new MockClienteService().MockGetByID(new ClienteDTO());

            var controller = new EnderecosController(mockEnderecoService.Object, mockClienteService.Object);

            //Act
            var result = await controller.Get(1);

            //Assert
            OkObjectResult okObjectResult = result.Result as OkObjectResult;
            var model = okObjectResult.Value as EnderecoDTO;

            Assert.IsAssignableFrom<OkObjectResult>(result.Result);
            Assert.NotNull(okObjectResult);
            Assert.NotNull(model);
        }

        [Fact]
        public async void EnderecoController_get_Invalid()
        {
            //Arrange
            var mockEnderecoService = new MockEnderecoService().MockGetByIDInvalid();
            var mockClienteService = new MockClienteService().MockGetByID(new ClienteDTO());

            var controller = new EnderecosController(mockEnderecoService.Object, mockClienteService.Object);

            //Act
            // var result = await controller.Get(1);

            //Assert
            await Assert.ThrowsAsync<Exception>(() => controller.Get(1));
        }

        [Fact]
        public async void EnderecoController_getall_Valid()
        {
            //Arrange
            var mockEndereco = new List<EnderecoDTO>()
            {
                new EnderecoDTO() { Id = 1 },
                new EnderecoDTO() { Id = 2 },
            };

            var mockEnderecoService = new MockEnderecoService().MockGetAll(mockEndereco);
            var mockClienteService = new MockClienteService().MockGetByID(new ClienteDTO());

            var controller = new EnderecosController(mockEnderecoService.Object, mockClienteService.Object);

            //Act
            var result = await controller.Get();

            //Assert
            OkObjectResult okObjectResult = result.Result as OkObjectResult;
            var model = okObjectResult.Value as List<EnderecoDTO>;

            Assert.IsAssignableFrom<OkObjectResult>(result.Result);
            Assert.NotNull(okObjectResult);
            Assert.NotNull(model);
        }

        [Fact]
        public async void EnderecoController_getall_Invalid()
        {
            //Arrange
            var mockEnderecoService = new MockEnderecoService().MockGetAllInvalid();
            var mockClienteService = new MockClienteService().MockGetByID(new ClienteDTO());

            var controller = new EnderecosController(mockEnderecoService.Object, mockClienteService.Object);

            //Act
            // var result = await controller.Get();

            //Assert
            await Assert.ThrowsAsync<Exception>(() => controller.Get());
        }

        [Fact]
        public async void EnderecoController_getall_Vazio()
        {
            //Arrange
            var mockEnderecoService = new MockEnderecoService().MockGetAllVazio();
            var mockClienteService = new MockClienteService().MockGetByID(new ClienteDTO());

            var controller = new EnderecosController(mockEnderecoService.Object, mockClienteService.Object);

            //Act
            var result = await controller.Get();

            //Assert
            OkObjectResult okObjectResult = result.Result as OkObjectResult;
            var model = okObjectResult.Value as List<EnderecoDTO>;

            Assert.IsAssignableFrom<OkObjectResult>(result.Result);
            Assert.NotNull(okObjectResult);
            Assert.NotNull(model);
        }

        [Fact]
        public async void EnderecoController_add_Valid()
        {
            //Arrange
            var mockEndereco = new EnderecoDTO()
            {
                Id = 1,
                Logradouro = "Rua tal",
                Bairro = "Tio Juca",
                Cidade = "Rio De Jardeiro",
                Estado = "Rio de Fevereiro",
                ClienteId = 1
            };

            var mockEnderecoService = new MockEnderecoService().MockAdd(mockEndereco);
            var mockClienteService = new MockClienteService().MockGetByID(new ClienteDTO());

            var controller = new EnderecosController(mockEnderecoService.Object, mockClienteService.Object);

            //Act
            ValidacaoModel.SimularValidacaoEndereco(mockEndereco, controller);
            var result = await controller.Post(mockEndereco);

            //Assert
            CreatedAtRouteResult okObjectResult = result as CreatedAtRouteResult;

            Assert.IsAssignableFrom<CreatedAtRouteResult>(result);
            Assert.NotNull(okObjectResult);
        }

        [Fact]
        public async System.Threading.Tasks.Task EnderecoController_add_InValid()
        {
            //Arrange
            var mockEndereco = new EnderecoDTO()
            {
                Id = 1,
                Logradouro = "Rua tal",
                Bairro = "Tio Juca",
                Cidade = "Rio De Jardeiro",
                Estado = "Rio de Fevereiro",
                ClienteId = 1
            };

            var mockEnderecoService = new MockEnderecoService().MockAddInvalid(mockEndereco);
            var mockClienteService = new MockClienteService().MockGetByID(new ClienteDTO());

            var controller = new EnderecosController(mockEnderecoService.Object, mockClienteService.Object);

            //Act
            // var result = await controller.Post(mockEndereco);

            //Assert
            await Assert.ThrowsAsync<Exception>(() => controller.Post(mockEndereco));
        }

        [Fact]
        public async void EnderecoController_update_Valid()
        {
            //Arrange
            var mockEndereco = new EnderecoDTO()
            {
                Id = 1,
                Logradouro = "Rua tal",
                Bairro = "Tio Juca",
                Cidade = "Rio De Jardeiro",
                Estado = "Rio de Fevereiro",
                ClienteId = 1
            };

            var mockEnderecoService = new MockEnderecoService().MockUpdate(mockEndereco);
            var mockClienteService = new MockClienteService().MockGetByID(new ClienteDTO());

            var controller = new EnderecosController(mockEnderecoService.Object, mockClienteService.Object);

            //Act
            var result = await controller.Put(1, mockEndereco);

            //Assert
            OkResult okObjectResult = result as OkResult;

            Assert.IsAssignableFrom<OkResult>(result);
            Assert.NotNull(okObjectResult);
        }

        [Fact]
        public async System.Threading.Tasks.Task EnderecoController_update_InValid()
        {
            //Arrange
            var mockEndereco = new EnderecoDTO()
            {
                Id = 1,
                Logradouro = "Rua tal",
                Bairro = "Tio Juca",
                Cidade = "Rio De Jardeiro",
                Estado = "Rio de Fevereiro",
                ClienteId = 1
            };

            var mockEnderecoService = new MockEnderecoService().MockUpdateInvalid(mockEndereco);
            var mockClienteService = new MockClienteService().MockGetByID(new ClienteDTO());

            var controller = new EnderecosController(mockEnderecoService.Object, mockClienteService.Object);

            //Act
            // var result = await controller.Post(mockEndereco);

            //Assert
            await Assert.ThrowsAsync<Exception>(() => controller.Put(1, mockEndereco));
        }

    }
}
