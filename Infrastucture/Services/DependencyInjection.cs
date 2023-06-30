using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Infrastucture.Persistence;
using Application.Data;
using MySql.EntityFrameworkCore;
using Domain.Primitives;
using Domain.Customers;
using Domain.Reservation;
using Domain.Packages;
using Infrastructure.Persistence.Repositories;

namespace Infrastucture;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPersistence(configuration);
        return services;
    }
    private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options=> options.UseMySQL(configuration.GetConnectionString("MySQL")));
        services.AddScoped<IApplicationDbContext>(sp=> sp.GetRequiredService<ApplicationDbContext>());
        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<IcustomerRepository, CustomerRepository>();
        services.AddScoped<IReserveRepository, ReserveRepository>();
        services.AddScoped<IPackageRepository, PackageRepository>();
        return services;
    }
}