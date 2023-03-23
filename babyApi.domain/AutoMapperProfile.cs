using AutoMapper;
using babyApi.domain.Dto;

namespace babyApi.domain
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<User, UserDto>()
                .ReverseMap();
              


            CreateMap<Activity, ActivityDto>()
                .ForMember(acDto => acDto.IdDto, ac => ac.MapFrom(ac => ac.Id))
                .ForMember(acDto => acDto.NameActivityDto, ac => ac.MapFrom(ac => ac.NameActivity))
                .ForMember(acDto => acDto.CodeActivityDto, ac => ac.MapFrom(ac => ac.CodeActivity))
                .ForMember(acDto => acDto.IconDto, ac => ac.MapFrom(ac => ac.Icon))
                .ReverseMap();




            CreateMap<BabyActivity, BabyActivityDto>();

            CreateMap<BabyProfile, BabyProfileDto>();
        }
    }
}
