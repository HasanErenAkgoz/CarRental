using Application.Features.Models.Queryies.GetAll;
using Application.Features.Models.Queryies.GetListByDynamic;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Models.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Model,GetAllResponse<GetAllModelListItemDto>>().ReverseMap();
        CreateMap<Model, GetAllByDynamicModelListItemDto>()
            .ForMember(destinationMember: c => c.BrandName, memberOptions: opt => opt.MapFrom(c => c.Brand.Name))
            .ReverseMap();       
        CreateMap<Paginate<Model>, GetAllResponse<GetAllModelListItemDto>>().ReverseMap();
        CreateMap<Paginate<Model>, GetAllResponse<GetAllByDynamicModelListItemDto>>().ReverseMap();
    }
}