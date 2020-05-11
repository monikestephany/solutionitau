using FluentValidation;
using FluentValidation.TestHelper;
using itau.doc.api.core.Entities;
using itau.doc.api.core.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using static itau.doc.api.core.Entities.Enum.DocEnum;

namespace itau.doc.api.test.Validators
{
    public class DocValidatorTest
    {
        private readonly DocValidator validations;
        private readonly Doc doc;

        public DocValidatorTest()
        {
            doc = new Doc
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
            validations = new DocValidator();
        }
        [Fact]
        public void DataIsNull()
        {
            Assert.Throws<ArgumentException>(() => validations.ShouldHaveValidationErrorFor(person => person.Data, doc));
        }
        [Fact]
        public void ValorIsNull()
        {
            doc.Valor = 0;
            Assert.Throws<ArgumentException>(() => validations.ShouldHaveValidationErrorFor(person => person.Valor, doc));
        }

    }
}
