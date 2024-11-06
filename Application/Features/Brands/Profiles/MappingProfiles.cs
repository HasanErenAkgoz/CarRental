using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Commands.Delete;
using Application.Features.Brands.Commands.Update;
using Application.Features.Brands.Queryies.GetAll;
using Application.Features.Brands.Queryies.GetById;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Brands.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() {
            //Create
            CreateMap<Brand, CreateBrandCommand>().ReverseMap();
            CreateMap<Brand, CreatedBrandResponse>().ReverseMap();

            //Update
            CreateMap<Brand, UpdatedBrandCommand>().ReverseMap();
            CreateMap<Brand, UpdatedBrandResponse>().ReverseMap();
            
            //Delete
            CreateMap<Brand, DeleteBrandCommand>().ReverseMap();
            CreateMap<Brand, DeleteBrandResponse>().ReverseMap();
          
            //GetAll
            CreateMap<Brand, GetAllBrandListItemDto>().ReverseMap();
            CreateMap<Paginate<Brand>, GetAllResponse<GetAllBrandListItemDto>>().ReverseMap();
            //GetById
            CreateMap<Brand, GetByIdBrandResponse>().ReverseMap();

        }
    }
}
