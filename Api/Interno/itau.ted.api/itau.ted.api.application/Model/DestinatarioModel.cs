﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace itau.ted.api.application.Model
{
    public class DestinatarioModel
    {
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Agencia { get; set; }
        public string Conta { get; set; }
        public string Banco { get; set; }
    }
}
