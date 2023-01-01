using SecurityPlayground.Application.Common.Interfaces;
using SecurityPlaygroundApi.Services;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddSingleton<ICurrentUserService, CurrentUserService>();

        services.AddHttpContextAccessor();

        return services;
    }
}
