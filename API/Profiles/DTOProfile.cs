using API.DTOs;
using API.Models;
using AutoMapper;

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
