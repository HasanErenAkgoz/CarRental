using Application.Features.Brands.Queryies.GetAll;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Request;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Model = Domain.Entities.Model;

namespace Application.Features.Models.Queryies.GetAll;

public class GetAllModelQuery : IRequest<GetAllResponse<GetAllModelListItemDto>>
{
    public PageRequest PageRequest { get; set; }
    
    public class  GetAllModelQueryHandler : IRequestHandler<GetAllModelQuery,GetAllResponse<GetAllModelListItemDto>>
    {
        private readonly IModelRepository _modelRepository;
        private readonly IMapper _mapper;

        public GetAllModelQueryHandler(IModelRepository modelRepository, IMapper mapper)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
        }
        public async Task<GetAllResponse<GetAllModelListItemDto>> Handle(GetAllModelQuery request, CancellationToken cancellationToken)
        {
           Paginate<Model> models = await _modelRepository.GetListAsync(
                include: m => m.Include(m => m.Brand),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize);
            
            GetAllResponse<GetAllModelListItemDto> response = _mapper.Map<GetAllResponse<GetAllModelListItemDto>>(models);
            return response;
        }
    }
}