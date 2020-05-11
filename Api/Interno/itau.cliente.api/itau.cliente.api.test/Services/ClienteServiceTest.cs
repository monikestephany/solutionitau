using FluentValidation;
using FluentValidation.Results;
using itau.cliente.api.core.Contracts.Repositories;
using itau.cliente.api.core.Entities;
using itau.cliente.api.core.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;
using static itau.cliente.api.core.Entities.Enum.Enum;

namespace itau.cliente.api.test.Services
{
    public class ClienteServiceTest
    {
        private readonly ClienteService clienteService;
        private Cliente cliente1;
        private Cliente clienteAlterado;
        public ClienteServiceTest()
        {
            cliente1 = new Cliente
            {
                Id = "1",
                Nome = "Monike Stephany Santana",
                CPF = "39124368865",
                RG = "506712308",
                DataNascimento = Convert.ToDateTime("21/05/1996"),
                NomeMae = "Luciana Aparecida Santana",
                NomePai = "Sergio Clei Santana",
                Contatos = new List<Contato> {
                    new Contato
                    {
                        DDD = 11,
                        Numero = 983189474,
                        Tipo = TipoContato.Celular
                    }
                },
                Endereco = new Endereco 
                { 
                    Bairro = "Jardim Guarau", 
                    Numero = 65, CEP = "05544210", 
                    Cidade = "São Paulo", 
                    Estado = "SP", 
                    Logradouro = "Rua João Angola do Amaral", 
                    Principal = true, 
                    TipoEndereco = TipoEndereco.Residencial 
                }
            };
            clienteAlterado = new Cliente
            {
                Id = "1",
                Nome = "Monike Stephany Santana",
                CPF = "39124368865",
                RG = "506712308",
                DataNascimento = Convert.ToDateTime("21/05/1996"),
                NomeMae = "Luciana Aparecida Santana",
                NomePai = "Sergio Clei Santana",
                Contatos = new List<Contato> {
                    new Contato
                    {
                        DDD = 11,
                        Numero = 983189474,
                        Tipo = TipoContato.Celular
                    },
                    new Contato
                    {
                        DDD = 21,
                        Numero = 999999999,
                        Tipo = TipoContato.Celular
                    }
                },
                Endereco = new Endereco
                {
                    Bairro = "Jardim Guarau",
                    Numero = 65,
                    CEP = "05544210",
                    Cidade = "São Paulo",
                    Estado = "SP",
                    Logradouro = "Rua João Angola do Amaral",
                    Principal = true,
                    TipoEndereco = TipoEndereco.Residencial
                }
            };
            var mockRepository = new Mock<IClienteRepository>();
            mockRepository.Setup(p => p.Get()).Returns(new List<Cliente> { cliente1 });
            mockRepository.Setup(p => p.GetCPF("39124368865")).Returns(cliente1);
            mockRepository.Setup(p => p.Create(cliente1)).Returns(cliente1);
            mockRepository.Setup(p => p.Update("1", clienteAlterado)).Returns(clienteAlterado);
            mockRepository.Setup(p => p.Remove(cliente1));
            var mockValitor = new Mock<IValidator<Cliente>>();
            mockValitor.Setup(x => x.Validate(It.IsAny<Cliente>()))
            .Returns(new ValidationResult());
            clienteService = new ClienteService(mockRepository.Object, mockValitor.Object);
        }
        [Fact]
        public void CreateTest()
        {
            var result = clienteService.Create(cliente1);
            Assert.Equal(result.CPF, cliente1.CPF);
        }
        [Fact]
        public void DeleteTest()
        {
            try
            {
                clienteService.Delete("1");
                Assert.True(true);
            }
            catch
            {
                Assert.True(false);
            }
        }
        [Fact]
        public void GetAllTest()
        {
            var result = clienteService.GetAll();
            Assert.NotEmpty(result);
        }
        [Fact]
        public void GetCPFTest()
        {
            var result = clienteService.GetCPF("39124368865");
            Assert.NotNull(result);
        }
        [Fact]
        public void UpdateTest()
        {
            var result = clienteService.Update("1", clienteAlterado);
            Assert.NotNull(result);
        }
    }
}
