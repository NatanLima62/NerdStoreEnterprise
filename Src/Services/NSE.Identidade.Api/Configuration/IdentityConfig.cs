using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NSE.Identidade.Api.Data;
using NSE.Identidade.Api.Extensions;

namespace NSE.Identidade.Api.Configuration;

public static class IdentityConfig
{
    public static void AddIdentityConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddDefaultIdentity<IdentityUser>()
            .AddRoles<IdentityRole>()
            .AddErrorDescriber<IdentityMensagensPortugues>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
        
        #region Jwt

        var appSettingsSection = configuration.GetSection("AppSettings");
        services.Configure<AppSettings>(appSettingsSection);
        var appSettings = appSettingsSection.Get<AppSettings>();
        var key = Encoding.ASCII.GetBytes(appSettings.Secret);

        services.AddAuthentication(optios =>
        {
            optios.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            optios.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(bearerOptions =>
        {
            bearerOptions.RequireHttpsMetadata = true;
            bearerOptions.SaveToken = true;
            bearerOptions.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidIssuer = appSettings.Emissor,
                ValidAudience = appSettings.ValidoEm
            };
        });

        #endregion
    }
    
    public static void UseIdentityConfiguration(this IApplicationBuilder app)
    {
        app.UseAuthorization();

        app.UseAuthentication();
    }
}