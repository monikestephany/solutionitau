using FluentValidation;
using itau.cliente.api.core.Contracts.Repositories;
using itau.cliente.api.core.Entities;
using itau.cliente.api.core.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace itau.cliente.api.core.Validators
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        private readonly ContatoValidator contatoValidator;
        private readonly EnderecoValidator enderecoValidator;
        private readonly IClienteRepository clienteRepository;
        string mensagem = "Campo Invalido : ";
        public ClienteValidator(IClienteRepository clienteRepository)
        {
            this.clienteRepository = clienteRepository;
            contatoValidator = new ContatoValidator();
            enderecoValidator = new EnderecoValidator();
            RuleFor(p => p.Nome).NotNull().NotEmpty().OnAnyFailure(x =>
            {
                throw new ArgumentException(mensagem + nameof(x.Nome));
            });
            RuleFor(p => p.NomeMae).NotNull().NotEmpty().OnAnyFailure(x =>
            {
                throw new ArgumentException(mensagem + nameof(x.NomeMae));
            });
            RuleFor(p => p.NomePai).NotNull().NotEmpty().OnAnyFailure(x =>
            {
                throw new ArgumentException(mensagem + nameof(x.NomePai));
            });
            RuleFor(p => p.RG).NotNull().NotEmpty().MinimumLength(8).OnAnyFailure(x =>
            {
                throw new ArgumentException(mensagem + nameof(x.RG));
            });
            RuleFor(p => p.CPF).NotNull().NotEmpty().Must(CPFIsValid).Must(CPFNotExist).OnAnyFailure(x =>
            {
                throw new ArgumentException(mensagem + nameof(x.CPF));
            });
            RuleFor(p => p.DataNascimento).NotNull().NotEmpty().LessThan(DateTime.Now).OnAnyFailure(x =>
            {
                throw new ArgumentException(mensagem + nameof(x.DataNascimento));
            });
            RuleForEach(p => p.Contatos).SetValidator(contatoValidator).OnAnyFailure(x =>
            {
                throw new ArgumentException(mensagem + nameof(x.Contatos));
            });
            RuleFor(p => p.Endereco).SetValidator(enderecoValidator).OnAnyFailure(x =>
            {
                throw new ArgumentException(mensagem +nameof(x.Endereco));
            });
        }
        private bool CPFIsValid(string cpf)
        {
            return Validations.ValidateCPF(cpf);     
        }
        private bool CPFNotExist(string cpf)
        {
            return (!clienteRepository.CPFExists(cpf));
        }
    }
}
