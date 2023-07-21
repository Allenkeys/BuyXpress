using BuyXpress.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BuyXpress.Extensions
{
    public static class ServicesExtensions
    {
        public static void AddDbConnection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BuyXpressDbContext>(option =>
                option.UseSqlServer(configuration.GetConnectionString("DbConn"))
            );
        }
    }
}
