using AutoMapper;
using itau.cliente.api.application.Model;
using itau.cliente.api.core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace itau.cliente.api.application.Mapper
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<ClienteCreateModel, Cliente>();
            CreateMap<ContatoModel, Contato>();
            CreateMap<EnderecoModel, Endereco>();
            CreateMap<ClienteUpdateModel, Cliente>();
        }
    }
}
