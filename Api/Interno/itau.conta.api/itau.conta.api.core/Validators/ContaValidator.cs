using FluentValidation;
using itau.conta.api.core.Entities;
using itau.conta.api.core.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace itau.conta.api.core.Validators
{
    public class ContaValidator : AbstractValidator<Conta>
    {
        string mensagem = "Campo Invalido : ";
        public ContaValidator()
        {
            RuleFor(p => p.Nome).NotNull().NotEmpty().OnAnyFailure(x =>
            {
                throw new ArgumentException(mensagem + nameof(x.Nome));
            });
            RuleFor(p => p.NumeroAgencia).NotNull().NotEmpty().OnAnyFailure(x =>
            {
                throw new ArgumentException(mensagem + nameof(x.NumeroAgencia));
            });
            RuleFor(p => p.NumeroConta).NotNull().NotEmpty().OnAnyFailure(x =>
            {
                throw new ArgumentException(mensagem + nameof(x.NumeroConta));
            });
            RuleFor(p => p.Senha).NotNull().NotEmpty().OnAnyFailure(x =>
            {
                throw new ArgumentException(mensagem + nameof(x.Senha));
            });
            RuleFor(p => p.Email).NotNull().NotEmpty().Must(EmailValido).OnAnyFailure(x =>
            {
                throw new ArgumentException(mensagem + nameof(x.Email));
            });
            RuleFor(p => p.CPF).NotNull().NotEmpty().Must(CPFValido).OnAnyFailure(x =>
            {
                throw new ArgumentException(mensagem + nameof(x.CPF));
            });
            RuleFor(p => p.DataNascimento).NotNull().NotEmpty().Must(Maioridade).OnAnyFailure(x =>
            {
                throw new ArgumentException(mensagem + nameof(x.DataNascimento));
            });
        }
        private bool CPFValido(string cpf)
        {
            return Validations.ValidateCPF(cpf);
        }
        private bool Maioridade(DateTime nascimento)
        {
            return Validations.VerificarMaioridade(nascimento);
        }
        private bool EmailValido(string email)
        {
            return Validations.ValidaEnderecoEmail(email);
        }
    }
}
