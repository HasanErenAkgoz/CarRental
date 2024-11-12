using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Request;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Queryies.GetAll
{
    public class GetAllBrandQuery : IRequest<GetAllResponse<GetAllBrandListItemDto>>, ICachableRequest
    {
        public PageRequest PageRequest { get; set; }
        public string CacheKey => $"GetAllBrandQuery({PageRequest.PageIndex},{PageRequest.PageSize})";
        public bool BypassCache {get;}
        public TimeSpan? SlidingExpiration { get; }
        public class GetAllBrandQueryHandler : IRequestHandler<GetAllBrandQuery, GetAllResponse<GetAllBrandListItemDto>>
        {
            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;

            public GetAllBrandQueryHandler(IBrandRepository brandRepository, IMapper mapper)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
            }

            public async Task<GetAllResponse<GetAllBrandListItemDto>> Handle(GetAllBrandQuery request,
                CancellationToken cancellationToken)
            {
                Paginate<Brand> brands = await _brandRepository.GetListAsync(
                    withDeleted: true,
                    index: request.PageRequest.PageIndex,
                    size: request.PageRequest.PageSize,
                    cancellationToken: cancellationToken);

                GetAllResponse<GetAllBrandListItemDto> response =
                    _mapper.Map<GetAllResponse<GetAllBrandListItemDto>>(brands);

                return response;
            }
        }
    }
}