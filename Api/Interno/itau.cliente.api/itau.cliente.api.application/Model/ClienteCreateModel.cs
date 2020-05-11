using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace itau.cliente.api.application.Model
{
    public class ClienteCreateModel
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public DateTime DataNascimento { get; set; }
        public string NomeMae { get; set; }
        public string NomePai { get; set; }
        public ICollection<ContatoModel> Contatos { get; set; }
        public EnderecoModel Endereco { get; set; }
    }
}
