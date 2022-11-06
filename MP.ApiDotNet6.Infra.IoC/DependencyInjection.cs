using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MP.ApiDotNet6.Application.Mappings;
using MP.ApiDotNet6.Application.Services;
using MP.ApiDotNet6.Application.Services.Interfaces;
using MP.ApiDotNet6.Domain.Authentication;
using MP.ApiDotNet6.Domain.Integrations;
using MP.ApiDotNet6.Domain.Repositories;
using MP.ApiDotNet6.Infra.Data.Authentication;
using MP.ApiDotNet6.Infra.Data.Context;
using MP.ApiDotNet6.Infra.Data.Integrations;
using MP.ApiDotNet6.Infra.Data.Repositories;

namespace MP.ApiDotNet6.Infra.IoC
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
			services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
			services.AddScoped<IPersonRepository, PersonRepository>();
			services.AddScoped<IProductRepository, ProductRepository>();
			services.AddScoped<IPurchaseRepository, PurchaseRepository>();
			services.AddScoped<IUnitOfWork, UnitOfWork>();
			services.AddScoped<ITokenGenerator, TokenGenerator>();
			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<IPersonImageRepository, PersonImageRepository>();
			services.AddScoped<ISavePersonImage,SavePersonImage>();
			return services;
        }

		public static IServiceCollection AddService(this IServiceCollection services, IConfiguration configuration)
        {
			services.AddAutoMapper(typeof(DomainToDtoMappings));
			services.AddScoped<IPersonService, PersonService>();
			services.AddScoped<IProductService, ProductService>();
			services.AddScoped<IPurchaseService, PurchaseService>();
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IPersonImageService, PersonImageService>();			
			return services;
        }
	}
}

