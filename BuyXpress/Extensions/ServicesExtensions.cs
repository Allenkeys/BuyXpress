using System.Text;
using BuyXpress.Data.Context;
using BuyXpress.Data.Repository;
using BuyXpress.Models.Entities;
using BuyXpress.Services.Implementations;
using BuyXpress.Services.Infrastructure.JWT;
using BuyXpress.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace BuyXpress.Extensions
{
    public static class ServicesExtensions
    {
        public static void AddDbConnection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BuyXpressDbContext>(option =>
                option.UseSqlServer(configuration.GetSection("ConnectionStrings")["DbConn"])
            );
        }

        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IUnitOfWork, UnitOfWork<BuyXpressDbContext>>();
            services.AddScoped<IJWTAuthenticator, JWTAuthenticator>();
            return services;
        }

        public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("JwtConfig");

            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings["Issuer"],
                        ValidAudience = jwtSettings["Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings["Key"]))
                    };
                });
        }

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>(opt =>
            {
                opt.Password.RequiredLength = 8;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireDigit = true;
                opt.Password.RequireUppercase = true;
                opt.User.RequireUniqueEmail = true;
                opt.Password.RequireLowercase = false;
            })
            .AddEntityFrameworkStores<BuyXpressDbContext>()
            .AddDefaultTokenProviders();
        }
    }
}
