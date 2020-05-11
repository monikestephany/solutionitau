using FluentValidation.TestHelper;
using itau.cliente.api.core.Entities;
using itau.cliente.api.core.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using static itau.cliente.api.core.Entities.Enum.Enum;

namespace itau.cliente.api.test.Validators
{

    public class EnderecoValidatorTest
    {
        private readonly EnderecoValidator validations;
        private readonly Endereco endereco;

        public EnderecoValidatorTest()
        {
            this.validations = new EnderecoValidator();
            endereco = new Endereco 
            {
                Bairro = "TESTE",
                CEP = "TESTE",
                Cidade = "TESTE",
                Numero = 1,
                Estado = "SP",
                Logradouro = "TESTE",
                Principal = true,
                TipoEndereco = TipoEndereco.Residencial
            };
        }
        [Fact]
        public void BairroIsNull()
        {
            endereco.Bairro = null;
            Assert.Throws<ArgumentException>(() => validations.ShouldHaveValidationErrorFor(person => person.Bairro, endereco));
        }
        [Fact]
        public void CEPIsNull()
        {
            endereco.CEP = null;
            Assert.Throws<ArgumentException>(() => validations.ShouldHaveValidationErrorFor(person => person.CEP, endereco));
        }
        [Fact]
        public void CidadeIsNull()
        {
            endereco.Cidade = null;
            Assert.Throws<ArgumentException>(() => validations.ShouldHaveValidationErrorFor(person => person.Cidade, endereco));
        }
        [Fact]
        public void NumeroIsNull()
        {
            endereco.Numero = 0;
            Assert.Throws<ArgumentException>(() => validations.ShouldHaveValidationErrorFor(person => person.Numero, endereco));
        }
        [Fact]
        public void EstadoIsNull()
        {
            endereco.Estado = null;
            Assert.Throws<ArgumentException>(() => validations.ShouldHaveValidationErrorFor(person => person.Estado, endereco));
        }

        [Fact]
        public void EstadoIsLenght()
        {
            endereco.Estado = "sss";
            Assert.Throws<ArgumentException>(() => validations.ShouldHaveValidationErrorFor(person => person.Estado, endereco));
        }
        [Fact]
        public void LogradouroIsNull()
        {
            endereco.Logradouro = null;
            Assert.Throws<ArgumentException>(() => validations.ShouldHaveValidationErrorFor(person => person.Logradouro, endereco));
        }
    }
}
