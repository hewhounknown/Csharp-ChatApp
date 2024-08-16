using ChatApp.Application.Interfaces;
using ChatApp.Application.Services;
using ChatApp.Infrastructure.Repositories;

namespace ChatApp.Web
{
  public static class ModularService
  {
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
      services.AddApplicationServices();
      services.AddInfrastructureServices();
      return services;
    }

    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
      services.AddScoped<IAuth, AuthService>();
      return services;
    }

    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
      services.AddScoped<IUserRepository, UserRepository>();
      return services;
    }
  }
}
