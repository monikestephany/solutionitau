﻿using System;
using System.Collections.Generic;
using System.Text;

namespace itau.doc.ext.api.core.Entities
{
    public class Destinatario
    {
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Agencia { get; set; }
        public string Conta { get; set; }
        public string Banco { get; set; }
    }
}
