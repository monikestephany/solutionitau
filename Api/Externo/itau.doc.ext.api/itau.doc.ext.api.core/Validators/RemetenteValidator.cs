using FluentValidation;
using itau.doc.ext.api.core.Entities;
using itau.doc.ext.api.core.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace itau.doc.ext.api.core.Validators
{
    public class RemetenteValidator : AbstractValidator<Remetente>
    {
        string mensagem = "Campo Invalido : ";
        public RemetenteValidator()
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
