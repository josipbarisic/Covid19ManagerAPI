using API.DTOs;
using API.EFModels;
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
            CreateMap<LokacijaCreateDTO, LokacijaPacijenta>();
            CreateMap<LokacijaPacijenta, LokacijaCreateDTO>();
            CreateMap<LokacijaPacijenta, LokacijaReadDTO>();
            CreateMap<StanjePacijenta, StanjePacijentaReadDTO>();
            CreateMap<StanjeCreateDTO, StanjePacijenta>();
            CreateMap<PacijentUpdateDTO, _02Pacijent>();
        }
    }
}
