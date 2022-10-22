namespace EzTransaction.Controllers.Extensions;

using EzTransaction.Models.Config;
using EzTransaction.Repositories;
using EzTransaction.Repositories.Interfaces;
using EzTransaction.Services;
using EzTransaction.Services.Interfaces;

internal static class ServicesExtensions
{
    internal static void AddBusinessServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
    }

    internal static void AddBusinessRepositories(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
    }
}