using FluentValidation.TestHelper;
using itau.cliente.api.core.Contracts.Repositories;
using itau.cliente.api.core.Entities;
using itau.cliente.api.core.Validators;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using static itau.cliente.api.core.Entities.Enum.Enum;

namespace itau.cliente.api.test.Validators
{
    public class ClienteValidatorTest
    {
        private readonly ClienteValidator validations;
        private readonly Cliente cliente;
       public ClienteValidatorTest()
        {
            cliente = new Cliente
            {
                CPF = "39124368865",
                DataNascimento = DateTime.Now,
                Endereco = new Endereco 
                { 
                    Bairro = "TESTE",
                    CEP = "TESTE",
                    Cidade = "TESTE",
                    Numero = 1,
                    Estado = "SP",
                    Logradouro = "TESTE",
                    Principal = true,
                    TipoEndereco = TipoEndereco.Residencial
                },
                Nome = "teste",
                NomeMae = "teste",
                NomePai = "teste",
                RG = "506712308",
                Contatos = new List<Contato> 
                { 
                    new Contato 
                    { 
                        DDD = 11,
                        Numero = 55, 
                        Tipo = TipoContato.Celular
                    } 
                }
            };
            var mockFalse = new Mock<IClienteRepository>();
            this.validations = new ClienteValidator(mockFalse.Object);
        }
        [Fact]
        public void NomeIsNull()
        {
            Assert.Throws<ArgumentException>(() => validations.ShouldHaveValidationErrorFor(person => person.Nome, null as string));
        }
        [Fact]
        public void NomeMaeINull()
        {
            Assert.Throws<ArgumentException>(() => validations.ShouldHaveValidationErrorFor(person => person.NomeMae, null as string));
        }
        [Fact]
        public void NomePaiIsNull()
        {
            Assert.Throws<ArgumentException>(() => validations.ShouldHaveValidationErrorFor(person => person.NomePai, null as string));
        }

        [Fact]
        public void RGIsNull()
        {
            Assert.Throws<ArgumentException>(() => validations.ShouldHaveValidationErrorFor(person => person.RG, null as string));
        }
        [Fact]
        public void CPFIsNull()
        {
            Assert.Throws<ArgumentException>(() => validations.ShouldHaveValidationErrorFor(person => person.CPF, null as string));
        }
        [Fact]
        public void EnderecoIsNull()
        {
            Assert.Throws<ArgumentException>(() => validations.ShouldHaveValidationErrorFor(person => person.Endereco, null as object));
        }
        [Fact]
        public void DataNascimentoIsNull()
        {
            Assert.Throws<ArgumentException>(() => validations.ShouldHaveValidationErrorFor(person => person.DataNascimento, null as object));
        }
        [Fact]
        public void CpfExistsIsFalse()
        {
            cliente.CPF = "123";
            Assert.Throws<ArgumentException>(() => validations.ShouldHaveValidationErrorFor(person => person.CPF, cliente));
        }
    }

}
