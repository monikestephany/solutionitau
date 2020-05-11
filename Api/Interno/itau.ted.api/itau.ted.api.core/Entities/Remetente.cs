using System;
using System.Collections.Generic;
using System.Text;

namespace itau.ted.api.core.Entities
{
    public class Remetente
    {
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Agencia { get; set; }
        public string Conta { get; set; }
        public string Banco { get; set; }
    }
}
