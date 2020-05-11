using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using static itau.pos.api.core.Entities.Enum.PosEnum;

namespace itau.pos.api.core.Entities
{
    public class Pos
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string NumeroCartao { get; set; }
        public string Nome { get; set; }
        public string CodigoSeguranca { get; set; }
        public Bandeira Bandeira { get; set; }
        public string CPF { get; set; }
        public TipoTransacao Transacao { get; set; }
        public int TotalVezes { get; set; }
        public decimal ValorLimite { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public DateTime Validade { get; set; }
    }
}
