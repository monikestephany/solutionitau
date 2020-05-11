using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static itau.doc.api.core.Entities.Enum.DocEnum;

namespace itau.doc.api.application.Model
{
    public class DocCreateModel
    {
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public RemetenteModel Remetente { get; set; }
        public DestinatarioModel Destinatario { get; set; }
        public MeioTranferencia Meio { get; set; }
    }
}
