using AutoMapper;
using itau.doc.api.application.Model;
using itau.doc.api.core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace itau.ted.api.application.Mapper
{
    public class DocProfile : Profile
    {
        public DocProfile()
        {
            CreateMap<DocCreateModel, Doc>();
            CreateMap<RemetenteModel, Remetente>();
            CreateMap<DestinatarioModel, Destinatario>();
        }
    }
}
