using Application.Features.Brands.Commands.Update;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Commands.Delete;

public class DeleteBrandCommand : IRequest<DeleteBrandResponse> 
{
    public Guid Id { get; set; }
    public class DeleteBrandHandler : IRequestHandler<DeleteBrandCommand, DeleteBrandResponse>
    {
        private readonly IBrandRepository _brandRepository; 
        private readonly IMapper _mapper; 

        public DeleteBrandHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public async Task<DeleteBrandResponse> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = await _brandRepository.GetAsync(b => b.Id == request.Id, cancellationToken: cancellationToken);
            await _brandRepository.DeleteAsync(brand);
            var response = _mapper.Map<DeleteBrandResponse>(brand);
            return response;
        }
    }
}