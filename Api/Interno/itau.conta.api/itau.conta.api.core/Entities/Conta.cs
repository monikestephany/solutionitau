using itau.conta.api.core.Utils;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace itau.conta.api.core.Entities
{
    public class Conta
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string NumeroAgencia { get; private set; }
        public string NumeroConta { get; private set; }
        public string DigitoAgencia { get; private set; }
        public string DigitoConta { get; private set; }
        public int Senha { get; private set; }

        public void GerarNovaAgencia(int ultimo)
        {
            Random numAleatorio = new Random();
            this.NumeroAgencia = (ultimo + 1).ToString().PadLeft(4, '0') ;
            this.DigitoAgencia = numAleatorio.Next(1, 9).ToString();
        }
        public void GerarNovaConta(int ultimo)
        {
            Random numAleatorio = new Random();
            this.NumeroConta = (ultimo + 1).ToString().PadLeft(4, '0');
            this.DigitoConta = numAleatorio.Next(1, 9).ToString();
        }
        public void GerarSenha()
        {
            this.Senha = int.Parse(ContaUtils.GerarSenhas());
        }
        public Conta Update(Conta conta)
        {
            this.Email = string.IsNullOrEmpty(conta.Email) ? this.Email : conta.Email;
            this.Nome = string.IsNullOrEmpty(conta.Nome) ? this.Nome : conta.Nome;
            return this;
        }
        public Conta UpdateSenha(int senha)
        {
            this.Senha = senha;
            return this;
        }
    }
  
}
