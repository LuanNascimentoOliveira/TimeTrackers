using app.Models.DTO;
using app.Models.Entities;
using AutoMapper;

namespace app.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() { 

            CreateMap<TimeBank, TimeBankDto>().ReverseMap();
        }
    }
}
