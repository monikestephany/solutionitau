using System;
using System.Collections.Generic;
using System.Text;

namespace itau.cliente.ext.api.core.Entities
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public DateTime DataNascimento { get; set; }
        public string NomeMae { get; set; }
        public string NomePai { get; set; }
        public ICollection<Contato> Contatos { get; set; }
        public Endereco Endereco { get; set; }
     
    }
}
