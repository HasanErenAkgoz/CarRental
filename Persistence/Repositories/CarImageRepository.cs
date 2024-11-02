using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class CarImageRepository : EfRepositoryBase<CarImage, Guid, BaseDbContext>, ICarImageRepository
    {
        public CarImageRepository(BaseDbContext context) : base(context)
        {
        }
    }
}