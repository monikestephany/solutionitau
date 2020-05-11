using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static itau.cliente.api.core.Entities.Enum.Enum;

namespace itau.cliente.api.application.Model
{
    public class ContatoModel
    {
        public int Numero { get; set; }
        public int DDD { get; set; }
        public TipoContato Tipo { get; set; }
    }
}
