using API.DTOs;
using AutoMapper;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Profiles
{
    public class DTOProfile : Profile
    {
        public DTOProfile()
        {
            //Source -> Target
            CreateMap<Pacijent, PacijentReadDTO>();
            CreateMap<PacijentCreateDTO, Pacijent>();
            CreateMap<PacijentUpdateDTO, Pacijent>();
            CreateMap<Pacijent, PacijentUpdateDTO>();
        }
    }
}
