using FluentValidation.TestHelper;
using itau.doc.api.core.Entities;
using itau.doc.api.core.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace itau.doc.api.test.Validators
{
    public class DestinatarioValidatorTest
    {
        private readonly DestinatarioValidator validations;
        private readonly Destinatario destinatario;

        public DestinatarioValidatorTest()
        {
            destinatario = new Destinatario
            {
                Agencia = "0652",
                Banco = "237",
                Conta = "0065232",
                CPF = "12873385006",
                Nome = "Rodrigo"
            };
            validations = new DestinatarioValidator();
        }
        [Fact]
        public void AgenciaIsNull()
        {
            destinatario.Agencia = null;
            Assert.Throws<ArgumentException>(() => validations.ShouldHaveValidationErrorFor(person => person.Agencia, destinatario));
        }
        [Fact]
        public void BancoIsNull()
        {
            destinatario.Banco = null;
            Assert.Throws<ArgumentException>(() => validations.ShouldHaveValidationErrorFor(person => person.Banco, destinatario));
        }
        [Fact]
        public void ContaIsNull()
        {
            destinatario.Conta = null;
            Assert.Throws<ArgumentException>(() => validations.ShouldHaveValidationErrorFor(person => person.Conta, destinatario));
        }
        [Fact]
        public void CPFIsNull()
        {
            destinatario.CPF = null;
            Assert.Throws<ArgumentException>(() => validations.ShouldHaveValidationErrorFor(person => person.CPF, destinatario));
        }
        [Fact]
        public void CPFNotValid()
        {
            destinatario.CPF = "123456";
            Assert.Throws<ArgumentException>(() => validations.ShouldHaveValidationErrorFor(person => person.CPF, destinatario));
        }
        [Fact]
        public void NomeIsNull()
        {
            destinatario.Nome = null;
            Assert.Throws<ArgumentException>(() => validations.ShouldHaveValidationErrorFor(person => person.Nome, destinatario));
        }
    }
}
