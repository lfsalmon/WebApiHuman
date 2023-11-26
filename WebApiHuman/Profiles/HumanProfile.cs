using AutoMapper;
using WebApiHumanModels.Data;
using WebApiHumanModels.ViewModels.Human;

namespace WebApiHuman.Profiles
{
    public class HumanProfile : Profile
    {
        public HumanProfile()
        {
            CreateMap<Human, AddHumanViewModel>().ReverseMap();
            CreateMap<Human, UpdateHumanViewModel>().ReverseMap();
        }
    }
}
