using API.EFModels;
using API.Models;
using AutoMapper;

namespace API.Profiles
{
    public class BaseClassProfile : Profile
    {
        public BaseClassProfile()
        {
            //Source -> Target
            CreateMap<_02Pacijent, Pacijent>();
            CreateMap<Pacijent, _02Pacijent>();
            CreateMap<_02Doktori, Doktor>();
            CreateMap<Doktor, _02Doktori>();
            CreateMap<_02LokacijaPacijenta, LokacijaPacijenta>();
            CreateMap<LokacijaPacijenta, _02LokacijaPacijenta>();
            CreateMap<_02StanjePacijenta, StanjePacijenta>();
            CreateMap<StanjePacijenta, _02StanjePacijenta>();
            CreateMap<_02StatusSifrarnik, StatusSifrarnik>();
            CreateMap<StatusSifrarnik, _02StatusSifrarnik>();
            CreateMap<_02Epidemiolog, Epidemiolog>();
            CreateMap<Epidemiolog, _02Epidemiolog>();
            CreateMap<_02Poruka, Poruka>();
            CreateMap<Poruka, _02Poruka>().ForMember(dest => dest.Poruka, opt => opt.MapFrom(src => src.Text_poruke));
        }
    }
}
