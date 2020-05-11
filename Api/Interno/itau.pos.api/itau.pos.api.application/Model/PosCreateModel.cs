using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static itau.pos.api.core.Entities.Enum.PosEnum;

namespace itau.pos.api.application.Model
{
    public class PosCreateModel
    {
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
