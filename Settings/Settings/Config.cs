using Data.Context;
using Data.Repositories;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services;
using Services.Interfaces;
using Services.Mapping;

namespace CrossCutting.Settings
{
    public static class Config
    {
        public static IServiceCollection AddInfrastruture(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ContextDb>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IPersonRepository, PersonRepository>();
            return services;
        }
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPersonService, PersonService>();
            services.AddAutoMapper(typeof(ToMappingDTO));
            return services;

        }
    }

}
