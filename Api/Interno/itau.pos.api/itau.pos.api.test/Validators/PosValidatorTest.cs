using FluentValidation.TestHelper;
using itau.pos.api.core.Entities;
using itau.pos.api.core.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using static itau.pos.api.core.Entities.Enum.PosEnum;

namespace itau.pos.api.test.Validators
{
    public class PosValidatorTest
    {
        private readonly PosValidator validations;
        private readonly Pos pos;

        public PosValidatorTest()
        {
            this.validations = new PosValidator();
            pos = new Pos 
            { 
                Bandeira = Bandeira.VISA,
                CodigoSeguranca = "630",
                NumeroCartao = "4485489265338195",
                Validade = DateTime.Parse("09/11/2021"),
                CPF = "11659328063",
                Nome = "Monike",
                Transacao = TipoTransacao.Debito,
                TotalVezes = 0,
                Valor = 500,
                ValorLimite = 1500,
                Data = DateTime.Now
            };
        }
        [Fact]
        public void CodigoSegurancaIsNull()
        {
             pos.CodigoSeguranca = null;
             Assert.Throws<ArgumentException>(() => validations.ShouldHaveValidationErrorFor(person => person.CodigoSeguranca, pos));
        }
        [Fact]
        public void CPFIsNull()
        {
            pos.CPF = null;
            Assert.Throws<ArgumentException>(() => validations.ShouldHaveValidationErrorFor(person => person.CPF, pos));
        }
        [Fact]
        public void CPFIsNotValid()
        {
            pos.CPF = "123456";
            Assert.Throws<ArgumentException>(() => validations.ShouldHaveValidationErrorFor(person => person.CPF, pos));
        }
        [Fact]
        public void TotalVezesDebitoIsNotValid()
        {
            pos.TotalVezes = 2;
            pos.Transacao = TipoTransacao.Debito;
            Assert.Throws<ArgumentException>(() => validations.ShouldHaveValidationErrorFor(person => person.TotalVezes, pos));
        }
        [Fact]
        public void TotalVezesCreditoIsNotValid()
        {
            pos.TotalVezes = 13;
            pos.Transacao = TipoTransacao.Credito;
            Assert.Throws<ArgumentException>(() => validations.ShouldHaveValidationErrorFor(person => person.TotalVezes, pos));
        }
        [Fact]
        public void ValorIsNull()
        {
            pos.Valor = 0;
            Assert.Throws<ArgumentException>(() => validations.ShouldHaveValidationErrorFor(person => person.Valor, pos));
        }
        [Fact]
        public void ValorLassLimite()
        {
            pos.Valor = 500;
            pos.ValorLimite = 200;
            Assert.Throws<ArgumentException>(() => validations.ShouldHaveValidationErrorFor(person => person.Valor, pos));
        }
        [Fact]
        public void ValorLimiteIsNull()
        {
            pos.ValorLimite = 0;
            Assert.Throws<ArgumentException>(() => validations.ShouldHaveValidationErrorFor(person => person.ValorLimite, pos));
        }
    }
}
