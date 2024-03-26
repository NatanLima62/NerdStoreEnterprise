using NSE.WebApp.Mvc.Service;

namespace NSE.WebApp.Mvc.Configuration;

public static class DependencyInjectionConfig
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddHttpClient<IAutenticacaoService, AutenticacaoService>();
    }
}