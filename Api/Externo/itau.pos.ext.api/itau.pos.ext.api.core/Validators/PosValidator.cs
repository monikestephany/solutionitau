using FluentValidation;
using itau.pos.ext.api.core.Entities;
using itau.pos.ext.api.core.Utils;
using System;
using static itau.pos.ext.api.core.Entities.Enum.PosEnum;

namespace itau.pos.ext.api.core.Validators
{
    public class PosValidator : AbstractValidator<Pos>
    {
        string mensagem = "Campo Invalido : ";
        public PosValidator()
        {
            RuleFor(p => p.CPF).NotNull().NotEmpty().Must(CPFValido).OnAnyFailure(x =>
            {
                throw new ArgumentException(mensagem + nameof(x.CPF));
            });
            RuleFor(p => p.NumeroCartao).NotNull().NotEmpty().OnAnyFailure(x =>
            {
                throw new ArgumentException(mensagem + nameof(x.NumeroCartao));
            });
            RuleFor(p => p.Nome).NotNull().NotEmpty().OnAnyFailure(x =>
            {
                throw new ArgumentException(mensagem + nameof(x.Nome));
            });
            RuleFor(p => p.TotalVezes).LessThan(13).OnAnyFailure(x =>
            {
                throw new ArgumentException(mensagem + nameof(x.TotalVezes));
            }).When(p => p.Transacao == TipoTransacao.Credito);

            RuleFor(p => p.Valor).NotNull().NotEmpty().OnAnyFailure(x =>
            {
                throw new ArgumentException(mensagem + nameof(x.Valor));
            });
            RuleFor(p => p.ValorLimite).NotNull().NotEmpty().OnAnyFailure(x =>
            {
                throw new ArgumentException(mensagem + nameof(x.ValorLimite));
            });
            RuleFor(p => p.Bandeira).NotNull().NotEmpty().OnAnyFailure(x =>
            {
                throw new ArgumentException(mensagem + nameof(x.Bandeira));
            });
            RuleFor(p => p.CodigoSeguranca).NotNull().NotEmpty().OnAnyFailure(x =>
            {
                throw new ArgumentException(mensagem + nameof(x.CodigoSeguranca));
            });
            RuleFor(p => p.TotalVezes).Empty().OnAnyFailure(x =>
            {
                throw new ArgumentException(mensagem + nameof(x.CodigoSeguranca));
            }).When(p => p.Transacao == TipoTransacao.Debito);

            RuleFor(p => p.Data).NotNull().NotEmpty().OnAnyFailure(x =>
            {
                throw new ArgumentException(mensagem + nameof(x.Data));
            });
            RuleFor(p => p.Validade).NotNull().NotEmpty().GreaterThan(DateTime.Now).OnAnyFailure(x =>
            {
                throw new ArgumentException(mensagem + nameof(x.Validade));
            });
            RuleFor(p => p).Must(p => ValidarCartao(p.NumeroCartao, p.Bandeira)).OnAnyFailure(x =>
            {
                throw new ArgumentException(mensagem + nameof(x.NumeroCartao));
            });
            RuleFor(p => p).Must(p => ValorMenorQueLimite(p.Valor, p.ValorLimite)).OnAnyFailure(x =>
            {
                throw new ArgumentException(mensagem + nameof(x.Valor));
            });
        }
        private bool CPFValido(string cpf)
        {
            return Validations.ValidateCPF(cpf);
        }
        private bool ValidarCartao(string numeroCartao, Bandeira bandeira)
        {
            return Validations.ValidarCartao(numeroCartao, bandeira);
        }
        private bool ValorMenorQueLimite(decimal valor, decimal limite)
        {
            return valor <= limite;
        }
    }
}
