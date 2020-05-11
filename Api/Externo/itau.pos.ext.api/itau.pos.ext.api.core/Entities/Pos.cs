using System;
using System.Collections.Generic;
using System.Text;
using static itau.pos.ext.api.core.Entities.Enum.PosEnum;

namespace itau.pos.ext.api.core.Entities
{
    public class Pos
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
