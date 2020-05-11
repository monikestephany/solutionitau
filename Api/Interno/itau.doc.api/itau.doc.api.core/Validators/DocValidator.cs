using FluentValidation;
using itau.doc.api.core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace itau.doc.api.core.Validators
{
    public class DocValidator : AbstractValidator<Doc>
    {
        string mensagem = "Campo Invalido : ";
        public DocValidator()
        {
            var validatorRemetente = new RemetenteValidator();
            var validatorDestinatario = new DestinatarioValidator();

            RuleFor(p => p.Tarifa).NotEmpty().NotNull().OnAnyFailure(x =>
            {
                throw new ArgumentException(mensagem + nameof(x.Tarifa));
            });
            RuleFor(p => p.Data).NotEmpty().NotNull().OnAnyFailure(x =>
            {
                throw new ArgumentException(mensagem + nameof(x.Data));
            });
            RuleFor(p => p.Remetente).NotNull().SetValidator(validatorRemetente);
            RuleFor(p => p.Destinatario).NotNull().SetValidator(validatorDestinatario);
        }
    }
}
