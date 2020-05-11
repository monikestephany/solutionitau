using FluentValidation;
using FluentValidation.TestHelper;
using itau.ted.api.core.Entities;
using itau.ted.api.core.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using static itau.ted.api.core.Entities.Enum.TedEnum;

namespace itau.ted.api.test.Validators
{
    public class TedValidatorTest
    {
        private readonly TedValidator validations;
        private readonly Ted ted;

        public TedValidatorTest()
        {
            ted = new Ted
            {
                Id = "1",
                Valor = 200,
                Meio = MeioTranferencia.Internet,
                Destinatario = new Destinatario
                {
                    Agencia = "0085",
                    Banco = "341",
                    Conta = "421512",
                    CPF = "73682426051",
                    Nome = "Monike"
                },
                Remetente = new Remetente
                {
                    Agencia = "0652",
                    Banco = "237",
                    Conta = "0065232",
                    CPF = "12873385006",
                    Nome = "Rodrigo"
                }
            };
            validations = new TedValidator();
        }
        [Fact]
        public void DataIsNull()
        {
            Assert.Throws<ArgumentException>(() => validations.ShouldHaveValidationErrorFor(person => person.Data, ted));
        }
        [Fact]
        public void ValorIsNull()
        {
            ted.Valor = 0;
            Assert.Throws<ArgumentException>(() => validations.ShouldHaveValidationErrorFor(person => person.Valor, ted));
        }

    }
}
