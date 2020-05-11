using AutoMapper;
using itau.conta.api.application.Model;
using itau.conta.api.core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace itau.conta.api.application.Mapper
{
    public class ContaProfile : Profile
    {
        public ContaProfile()
        {
            CreateMap<ContaCreateModel, Conta>();
            CreateMap<ContaUpdateModel, Conta>();
        }
    }
}
