using AutoMapper;
using Task4AuthWebApp.Entities;
using Task4AuthWebApp.Models;

namespace Task4AuthWebApp.MapperProfile
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserViewModel>().ReverseMap();
        }
    }
}
