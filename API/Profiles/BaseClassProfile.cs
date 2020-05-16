using AutoMapper;
using API.EFModels;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Profiles
{
    public class BaseClassProfile : Profile
    {
        public BaseClassProfile()
        {
            //Source -> Target
            CreateMap<_02Pacijent, Pacijent>();
            CreateMap<Pacijent, _02Pacijent>();
        }
    }
}
