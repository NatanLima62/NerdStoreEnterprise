namespace NSE.Identidade.Api.Configuration;

public static class ApiConfig
{
    public static void AddApiConfiguration(this IServiceCollection services)
    {
        services.AddControllers();
    }
    
    public static void UseApiConfiguration(this IApplicationBuilder app, IWebHostEnvironment environment)
    {
        if (environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();
        
        app.UseRouting();
        
        app.UseIdentityConfiguration();
        
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}