using AutoMapper;
using itau.pos.api.application.Model;
using itau.pos.api.core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace itau.pos.api.application.Mapper
{
    public class PosMapper : Profile
    {
        public PosMapper()
        {
            CreateMap<PosCreateModel, Pos>();
        }
    }
}
