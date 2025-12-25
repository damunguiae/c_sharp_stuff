using Microsoft.EntityFrameworkCore;
using ProductCatalog.Core.Interfaces;
using ProductCatalog.Core.Services;
using ProductCatalog.Infrastructure.Data;
using ProductCatalog.Infrastructure.Repositories;

namespace ProductCatalog.WebAPI.Extensions;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers Infrastructure layer services (DbContext, Repositories)
    /// </summary>
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // Get connection string
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException(
                "Connection string 'DefaultConnection' not found in configuration.");
        }

        // Register DbContext with PostgreSQL provider
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(connectionString);

            // Development-only settings
            if (configuration.GetValue<string>("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                options.EnableSensitiveDataLogging();
                options.EnableDetailedErrors();
            }
        });

        // Register repositories (Scoped - one instance per HTTP request)
        services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }

    /// <summary>
    /// Registers Core layer services (Business Logic)
    /// </summary>
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        // Register domain services (Scoped - one instance per HTTP request)
        services.AddScoped<IProductService, ProductService>();

        return services;
    }

    /// <summary>
    /// Registers application-level services (CORS, Controllers, etc.)
    /// </summary>
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Add Controllers
        services.AddControllers();

        // Add CORS policy
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });
        });

        return services;
    }
}