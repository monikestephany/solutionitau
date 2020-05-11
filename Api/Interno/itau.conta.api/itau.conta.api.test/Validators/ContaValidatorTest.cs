using FluentValidation.TestHelper;
using itau.conta.api.core.Entities;
using itau.conta.api.core.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace itau.conta.api.test.Validators
{
    public class ContaValidatorTest
    {
        private readonly ContaValidator validations;
        private readonly Conta conta;

        public ContaValidatorTest()
        {
            this.validations = new ContaValidator();
            conta = new Conta
            {
                Id = "1",
                CPF = "39124368865",
                DataNascimento = DateTime.Parse("1996-05-21"),
                Email = "monikestephany@gmail.com",
                Nome = "Monike Stephany Santana"
            };
        }
        [Fact]
        public void CPFIsNull()
        {
             conta.CPF = null;
             Assert.Throws<ArgumentException>(() => validations.ShouldHaveValidationErrorFor(person => person.CPF, conta));
        }
        [Fact]
        public void CPFIsNotValid()
        {
            conta.CPF = "123";
            Assert.Throws<ArgumentException>(() => validations.ShouldHaveValidationErrorFor(person => person.CPF, conta));
        }
        [Fact]
        public void NomeIsNull()
        {
            conta.Nome = null;
            Assert.Throws<ArgumentException>(() => validations.ShouldHaveValidationErrorFor(person => person.Nome, conta));
        }
        [Fact]
        public void EmailIsNull()
        {
             conta.Email = null;
             Assert.Throws<ArgumentException>(() => validations.ShouldHaveValidationErrorFor(person => person.Email, conta));
        }
        [Fact]
        public void EmailIsNotValid()
        {
             conta.Email = "teste";
             Assert.Throws<ArgumentException>(() => validations.ShouldHaveValidationErrorFor(person => person.Email, conta));
        }
        [Fact]
        public void NumeroAgenciaIsNull()
        {
             Assert.Throws<ArgumentException>(() => validations.ShouldHaveValidationErrorFor(person => person.NumeroAgencia, conta));
        }
        [Fact]
        public void DigitoAgenciaIsNull()
        {
             Assert.Throws<ArgumentException>(() => validations.ShouldHaveValidationErrorFor(person => person.DigitoAgencia, conta));
        }
        [Fact]
        public void NumeroContaIsNull()
        {
             Assert.Throws<ArgumentException>(() => validations.ShouldHaveValidationErrorFor(person => person.NumeroConta, conta));
        }
        [Fact]
        public void DigitoContaIsNull()
        {
             Assert.Throws<ArgumentException>(() => validations.ShouldHaveValidationErrorFor(person => person.DigitoConta, conta));
        }
        [Fact]
        public void SenhaIsEmpty()
        {
             Assert.Throws<ArgumentException>(() => validations.ShouldHaveValidationErrorFor(person => person.Senha, conta));
        }
    }
}
