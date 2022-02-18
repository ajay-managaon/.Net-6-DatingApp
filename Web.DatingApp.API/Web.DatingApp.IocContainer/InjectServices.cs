using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Web.DatingApp.API.Web.DatingApp.Database;
using Web.DatingApp.API.Web.DatingApp.Implenentations;
using Web.DatingApp.API.Web.DatingApp.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

namespace Web.DatingApp.API.Web.DatingApp.IocContainer
{
    public static class InjectServices
    {
        public static void InjectDependencies(this IServiceCollection services, WebApplicationBuilder builder)
        {
            builder.Services.AddCors();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<ITokenService, TokenService>();
            builder.Services.AddDbContext<DatingAppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DatingAppConnectionString"));
            });
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtTokenKey"])),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }
    }
}
