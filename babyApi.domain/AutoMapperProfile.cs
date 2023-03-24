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




            CreateMap<BabyActivity, BabyActivityDto>()
                .ForMember(bacDto => bacDto.IdDto, bac => bac.MapFrom(bac => bac.Id))
                .ForMember(bacDto => bacDto.InitialTimeDto,bac => bac.MapFrom(bac => bac.InitialTime))
                .ForMember(bacDto => bacDto.EndTimeDto, bac => bac.MapFrom(bac => bac.EndTime))
                .ForMember(bacDto => bacDto.DescriptionDto, bac => bac.MapFrom(bac => bac.Description))
                .ForMember(bacDto => bacDto.ActivityIdDto, bac => bac.MapFrom(bac => bac.ActivityId))
                .ForMember(bacDto => bacDto.ActivitiesDto, bac => bac.MapFrom(bac => bac.Activities))
                .ReverseMap();



            CreateMap<BabyProfile, BabyProfileDto>()
            .ForMember(bpDto => bpDto.IdDto, bp => bp.MapFrom(bp => bp.Id))
            .ForMember(bpDto => bpDto.UserIdDto, bp => bp.MapFrom(bp => bp.UserId))
            .ForMember(bpDto => bpDto.NameDto, bp => bp.MapFrom(bp => bp.Name))
            .ForMember(bpDto => bpDto.BirthDto, bp => bp.MapFrom(bp => bp.Birth))
            .ForMember(bpDto => bpDto.InicialWeightDto, bp => bp.MapFrom(bp => bp.InicialWeight))
            .ForMember(bpDto => bpDto.ActualWeightDto, bp => bp.MapFrom(bp => bp.ActualWeight))
            .ForMember(bpDto => bpDto.SizeDto, bp => bp.MapFrom(bp => bp.Size))
            .ReverseMap();






        }
    }
}
