using FluentValidation.TestHelper;
using itau.doc.api.core.Entities;
using itau.doc.api.core.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace itau.doc.api.test.Validators
{
    public class RemetenteValidatorTest
    {
        private readonly RemetenteValidator validations;
        private readonly Remetente remetente;

        public RemetenteValidatorTest()
        {
            remetente = new Remetente
            {
                Agencia = "0652",
                Banco = "237",
                Conta = "0065232",
                CPF = "12873385006",
                Nome = "Rodrigo"
            };
            validations = new RemetenteValidator();
        }
        [Fact]
        public void AgenciaIsNull()
        {
            remetente.Agencia = null;
            Assert.Throws<ArgumentException>(() => validations.ShouldHaveValidationErrorFor(person => person.Agencia, remetente));
        }
        [Fact]
        public void BancoIsNull()
        {
            remetente.Banco = null;
            Assert.Throws<ArgumentException>(() => validations.ShouldHaveValidationErrorFor(person => person.Banco, remetente));
        }
        [Fact]
        public void ContaIsNull()
        {
            remetente.Conta = null;
            Assert.Throws<ArgumentException>(() => validations.ShouldHaveValidationErrorFor(person => person.Conta, remetente));
        }
        [Fact]
        public void CPFIsNull()
        {
            remetente.CPF = null;
            Assert.Throws<ArgumentException>(() => validations.ShouldHaveValidationErrorFor(person => person.CPF, remetente));
        }
        [Fact]
        public void CPFNotValid()
        {
            remetente.CPF = "123456";
            Assert.Throws<ArgumentException>(() => validations.ShouldHaveValidationErrorFor(person => person.CPF, remetente));
        }
        [Fact]
        public void NomeIsNull()
        {
            remetente.Nome = null;
            Assert.Throws<ArgumentException>(() => validations.ShouldHaveValidationErrorFor(person => person.Nome, remetente));
        }
    }
}
