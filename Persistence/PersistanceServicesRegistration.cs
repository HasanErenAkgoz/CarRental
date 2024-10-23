using Application.Services.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class PersistanceServicesRegistration
    {
        public static IServiceCollection AddPersistanceServices(this IServiceCollection  services,IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(options => options.UseInMemoryDatabase("nArchitecture"));
            services.AddScoped<IBrandRepository, BrandRepository>();

            return services;
        }
    }
}
