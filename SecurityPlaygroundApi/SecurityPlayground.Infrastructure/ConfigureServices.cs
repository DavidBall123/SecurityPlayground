using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using SecurityPlayground.Infrastructure.Persistence.Interceptors;
using SecurityPlayground.Application.Common.Interfaces;
using SecurityPlayground.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using SecurityPlayground.Infrastructure.Persistence;

namespace SecurityPlayground.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<AuditableEntitySaveChangesInterceptor>();

        if (configuration.GetValue<bool>("UseInMemoryDatabase"))
        {
            services.AddDbContext<CertificateContext>(options =>
                options.UseInMemoryDatabase("SecurityPlaygroundDB"));
        }
        else
        {
            services.AddDbContext<CertificateContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("CertificateContext"),
                    builder => builder.MigrationsAssembly(typeof(CertificateContext).Assembly.FullName)));
        }

        services.AddScoped<ICertificateContext>(provider => provider.GetRequiredService<CertificateContext>());
        services.AddScoped<CertificateContextInitialiser>();

        services.AddTransient<IDateTime, DateTimeService>();

        return services;

    }
}
