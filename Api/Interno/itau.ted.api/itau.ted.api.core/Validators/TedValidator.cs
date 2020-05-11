using FluentValidation;
using itau.ted.api.core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace itau.ted.api.core.Validators
{
    public class TedValidator : AbstractValidator<Ted>
    {
        string mensagem = "Campo Invalido : ";
        public TedValidator()
        {
            var validatorRemetente = new RemetenteValidator();
            var validatorDestinatario = new DestinatarioValidator();

            RuleFor(p => p.Data).NotEmpty().NotNull().OnAnyFailure(x =>
            {
                throw new ArgumentException(mensagem + nameof(x.Data));
            });
            RuleFor(p => p.Remetente).NotNull().SetValidator(validatorRemetente);
            RuleFor(p => p.Destinatario).NotNull().SetValidator(validatorDestinatario);
        }
    }
}
