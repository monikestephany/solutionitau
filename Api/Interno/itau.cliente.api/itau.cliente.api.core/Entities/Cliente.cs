using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace itau.cliente.api.core.Entities
{
    public class Cliente
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Nome { get;  set; }
        public string CPF { get;  set; }
        public string RG { get;  set; }
        public DateTime DataNascimento { get;  set; }
        public string NomeMae { get;  set; }
        public string NomePai { get;  set; }
        public ICollection<Contato> Contatos { get;  set; }
        public Endereco Endereco { get;  set; }
        public Cliente Update(Cliente cliente)
        {
            Nome = cliente.Nome;
            Contatos = cliente.Contatos;
            Endereco = cliente.Endereco;
            return this;
        }
    }
}
