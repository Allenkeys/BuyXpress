using BuyXpress.Data.Context;
using BuyXpress.Data.Repository;
using BuyXpress.Models.Entities;
using BuyXpress.Services.Implementations;
using BuyXpress.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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
            return services;
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
