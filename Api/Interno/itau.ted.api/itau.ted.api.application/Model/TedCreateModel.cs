using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static itau.ted.api.core.Entities.Enum.TedEnum;

namespace itau.ted.api.application.Model
{
    public class TedCreateModel
    {
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public RemetenteModel Remetente { get; set; }
        public DestinatarioModel Destinatario { get; set; }
        public MeioTranferencia Meio { get; set; }
    }
}
