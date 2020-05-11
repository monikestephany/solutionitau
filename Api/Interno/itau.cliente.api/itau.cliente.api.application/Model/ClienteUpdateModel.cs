using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace itau.cliente.api.application.Model
{
    public class ClienteUpdateModel
    {
        public string Nome { get; set; }
        public ICollection<ContatoModel> Contatos { get; set; }
        public EnderecoModel Endereco { get; set; }
    }
}
