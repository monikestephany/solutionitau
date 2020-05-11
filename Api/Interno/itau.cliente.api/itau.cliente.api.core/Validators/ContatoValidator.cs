using FluentValidation;
using itau.cliente.api.core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace itau.cliente.api.core.Validators
{
    public class ContatoValidator : AbstractValidator<Contato>
    {
        public ContatoValidator()
        {
            RuleFor(p => p.DDD).NotNull().NotEmpty().OnAnyFailure(x =>
            {
                throw new ArgumentException(nameof(x.DDD));
            });
            RuleFor(p => p.Numero).NotNull().NotEmpty().OnAnyFailure(x =>
            {
                throw new ArgumentException(nameof(x.Numero));
            });
        }
    }
}
