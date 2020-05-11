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
    public class ContatoValidatorTest
    {
        private readonly ContatoValidator validations;
        private readonly Contato contato;

        public ContatoValidatorTest()
        {
            this.validations = new ContatoValidator();
            contato = new Contato { DDD = 11, Numero = 111111111, Tipo = TipoContato.Celular };
        }
        [Fact]
        public void DDDIsNull()
        {
            contato.DDD = 0;
            Assert.Throws<ArgumentException>(() => validations.ShouldHaveValidationErrorFor(person => person.DDD, contato));
        }
        [Fact]
        public void NumeroIsNull()
        {
            contato.Numero = 0;
            Assert.Throws<ArgumentException>(() => validations.ShouldHaveValidationErrorFor(person => person.Numero, contato));
        }
    }
}
