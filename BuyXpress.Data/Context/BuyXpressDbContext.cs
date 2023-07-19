﻿using BuyXpress.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BuyXpress.Data.Context
{
    public class BuyXpressDbContext : IdentityDbContext<ApplicationUser>
    {
        public BuyXpressDbContext(DbContextOptions<BuyXpressDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
