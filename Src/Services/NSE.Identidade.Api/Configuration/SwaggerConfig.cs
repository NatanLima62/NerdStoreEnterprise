using Microsoft.OpenApi.Models;

namespace NSE.Identidade.Api.Configuration;

public static class SwaggerConfig
{
    public static void AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "NerdStore Enterprise Identity API",
                Description = "Esta API faz parte do curso ASP.NET Core Enterprise Applications.",
                Contact = new OpenApiContact { Name = "NatanLima62", Email = "natanlimaoliveira62@gmail.com" },
                License = new OpenApiLicense { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
            });
        });
    }
    
    public static void UseSwaggerConfiguration(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"); });
    }
}