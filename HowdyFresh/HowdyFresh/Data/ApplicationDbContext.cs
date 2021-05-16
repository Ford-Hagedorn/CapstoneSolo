using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using HowdyFresh.Models;

namespace HowdyFresh.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public ApplicationDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>()
                .HasData(
                new IdentityRole
                {
                    Id = "7b7922e5-e3dd-4a72-9872-d6b1e850d133",
                    Name = "Restaurant",
                    NormalizedName = "RESTAURANT",
                    ConcurrencyStamp = "6d4501de-8421-4e56-b05b-5b14041b2c71"
                },
                new IdentityRole
                {
                    Id = "b60a3b84-3b04-4bcb-8932-c82299fc80fb",
                    Name = "Supplier",
                    NormalizedName = "SUPPLIER",
                    ConcurrencyStamp = "a91b9165-dc63-4558-8dc8-9143a89fe41c"
                }
                );
        }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Article> Article { get; set; }
        public DbSet<ArticleComment> ArticleComment { get; set; }
        public DbSet<HowdyFresh.Models.Product> Product { get; set; }
    }
}
