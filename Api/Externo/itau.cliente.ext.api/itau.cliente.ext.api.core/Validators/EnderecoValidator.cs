using FluentValidation;
using itau.cliente.ext.api.core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace itau.cliente.ext.api.core.Validators
{
    public class EnderecoValidator : AbstractValidator<Endereco>
    {
        public EnderecoValidator()
        {
            RuleFor(p => p.Logradouro).NotNull().NotEmpty().OnAnyFailure(x =>
            {
                throw new ArgumentException(nameof(x.Logradouro));
            });
            RuleFor(p => p.Bairro).NotNull().NotEmpty().OnAnyFailure(x =>
            {
                throw new ArgumentException(nameof(x.Bairro));
            });
            RuleFor(p => p.CEP).NotNull().NotEmpty().MaximumLength(8).OnAnyFailure(x =>
            {
                throw new ArgumentException(nameof(x.CEP));
            });
            RuleFor(p => p.Cidade).NotNull().NotEmpty().OnAnyFailure(x =>
            {
                throw new ArgumentException(nameof(x.Cidade));
            });
            RuleFor(p => p.Estado).NotNull().NotEmpty().Length(2).OnAnyFailure(x =>
            {
                throw new ArgumentException(nameof(x.Estado));
            });
            RuleFor(p => p.Numero).NotNull().NotEmpty().OnAnyFailure(x =>
            {
                throw new ArgumentException(nameof(x.Numero));
            });
            RuleFor(p => p.Principal).NotNull().NotEmpty().OnAnyFailure(x =>
            {
                throw new ArgumentException(nameof(x.Principal));
            });
        }
    }
}
