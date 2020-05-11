using AutoMapper;
using itau.ted.api.application.Model;
using itau.ted.api.core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace itau.ted.api.application.Mapper
{
    public class TedProfile : Profile
    {
        public TedProfile()
        {
            CreateMap<TedCreateModel, Ted>();
            CreateMap<RemetenteModel, Remetente>();
            CreateMap<DestinatarioModel, Destinatario>();
        }
    }
}
