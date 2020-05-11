using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using static itau.doc.api.core.Entities.Enum.DocEnum;

namespace itau.doc.api.core.Entities
{
    public class Doc
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public decimal Tarifa { get; private set; }
        public Remetente Remetente { get; set; }
        public Destinatario Destinatario { get; set; }
        public MeioTranferencia Meio { get; set; }

        public void CalcularTarifa()
        {
            switch (Meio)
            {
                case MeioTranferencia.Pessoal:
                    Tarifa = new decimal(13.30);
                    break;
                case MeioTranferencia.Eletronico:
                    Tarifa = new decimal(7.40);
                    break;
                case MeioTranferencia.Internet:
                    Tarifa = new decimal(7.40);
                    break;
                default:
                    break;
            }
        }
    }
  
}
