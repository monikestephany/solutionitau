using FluentValidation;
using itau.ted.api.core.Entities;
using itau.ted.api.core.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace itau.ted.api.core.Validators
{
    public class DestinatarioValidator : AbstractValidator<Destinatario>
    {
        string mensagem = "Campo Invalido : ";
        public DestinatarioValidator()
        {
            RuleFor(p => p.Nome).NotNull().NotEmpty().OnAnyFailure(x =>
            {
                throw new ArgumentException(mensagem + nameof(x.Nome));
            });
            RuleFor(p => p.CPF).NotNull().NotEmpty().Must(CPFValido).OnAnyFailure(x =>
            {
                throw new ArgumentException(mensagem + nameof(x.CPF));
            });
            RuleFor(p => p.Agencia).NotNull().NotEmpty().OnAnyFailure(x =>
            {
                throw new ArgumentException(mensagem + nameof(x.Agencia));
            });
            RuleFor(p => p.Conta).NotNull().NotEmpty().OnAnyFailure(x =>
            {
                throw new ArgumentException(mensagem + nameof(x.Conta));
            });
            RuleFor(p => p.Banco).NotNull().NotEmpty().OnAnyFailure(x =>
            {
                throw new ArgumentException(mensagem + nameof(x.Banco));
            });
        }
        private bool CPFValido(string cpf)
        {
            return Validations.ValidateCPF(cpf);
        }
    }
}
