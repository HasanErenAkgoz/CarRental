using Application.Features.Models.Queryies.GetAll;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Request;
using Core.Application.Responses;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Application.Features.Models.Queryies.GetListByDynamic;

public class GetAllByDynamicModelQuery : IRequest<GetAllResponse<GetAllByDynamicModelListItemDto>>
{
    public  PageRequest PageRequest { get; set; }
    public  DynamicQuery DynamicQuery;

    public class GetListByDynamicModelQueryHandler : IRequestHandler<GetAllByDynamicModelQuery,
        GetAllResponse<GetAllByDynamicModelListItemDto>>
    {
        private readonly IModelRepository _modelRepository;
        private readonly IMapper _mapper;

        public GetListByDynamicModelQueryHandler(IModelRepository modelRepository, IMapper mapper)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
        }


        public async Task<GetAllResponse<GetAllByDynamicModelListItemDto>> Handle(GetAllByDynamicModelQuery request, CancellationToken cancellationToken)
        {
            Paginate<Model> models = await _modelRepository.GetListByDynamicAsync(
                request.DynamicQuery,
                include: m => m.Include(m => m.Brand),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize);

            GetAllResponse<GetAllByDynamicModelListItemDto> response =  _mapper.Map<GetAllResponse<GetAllByDynamicModelListItemDto>>(models);
            return response;
        }
    }
}