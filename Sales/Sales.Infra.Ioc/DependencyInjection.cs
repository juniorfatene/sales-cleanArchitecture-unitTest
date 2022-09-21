using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sales.Application.Interfaces;
using Sales.Application.Mappings;
using Sales.Application.Services;
using Sales.Domain.Interfaces;
using Sales.Infra.Data.Context;
using Sales.Infra.Data.Repositories;

namespace Sales.Infra.Ioc;

public static class DependencyInjection
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services)
	{
		services.AddDbContext<ApplicationDbContext>(opt => opt.UseInMemoryDatabase("Pottencial"));

		services.AddScoped<IUnitOfWork, UnitOfWork>();
		services.AddScoped<ISaleRepository, SaleRepository>();
		services.AddScoped<ISaleService, SaleService>();
		services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

		return services;

	}
}
