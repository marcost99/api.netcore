using Application.Mappings;
using Application.Services;
using Application.Services.Interfaces;
using Domain.Repositories;
using Infra.Data.Context;
using Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<ApplicationDbContext>(options =>
            //                    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<ApplicationDbContext>(options =>
                                options.UseInMemoryDatabase("Database"));

            services.AddScoped<IPersonRepository, PersonRepository>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddAutoMapper(typeof(DomainToDtoMapping));
            services.AddScoped<IPersonService, PersonService>();
            return services;
        }
    }
}
