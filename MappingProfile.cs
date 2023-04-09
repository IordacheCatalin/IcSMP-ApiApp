using AutoMapper;
using IcSMP_ApiApp.DTOs;
using IcSMP_ApiApp.DTOs.CreateUpdateObjects;

namespace IcSMP_ApiApp
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CreateUpdateCategory>().ReverseMap();
        }
    }
}
