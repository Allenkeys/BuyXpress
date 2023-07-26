using BuyXpress.Data.Context;
using BuyXpress.Models.Enums;
using Microsoft.AspNetCore.Identity;

namespace BuyXpress.SeedData
{
    public static class Seed
    {
        public static async Task SeedAll(this IApplicationBuilder builder)
        {
            BuyXpressDbContext db = builder.ApplicationServices.CreateScope().ServiceProvider
                .GetRequiredService<BuyXpressDbContext>();
            
            if (db.Roles.Any())
                return;
            await db.Roles.AddRangeAsync(SeedRoles());
            await db.SaveChangesAsync();
        }
        public static IEnumerable<IdentityRole> SeedRoles()
        {
            return new List<IdentityRole>()
            {
                new IdentityRole()
                {
                    Name = UserType.Admin.ToStringValue(),
                    NormalizedName = UserType.Admin.ToStringValue()!.ToUpper().Normalize()
                },

                new IdentityRole()
                {
                    Name = UserType.Merchant.ToStringValue(),
                    NormalizedName = UserType.Merchant.ToStringValue()!.ToUpper().Normalize()
                },

                new IdentityRole()
                {
                    Name = UserType.Customer.ToStringValue(),
                    NormalizedName = UserType.Customer.ToStringValue()!.ToUpper().Normalize()
                }
            };
        }
    }
}
