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
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>()
                .HasData(
                new IdentityRole
                {
                    Name = "Restaurant",
                    NormalizedName = "RESTAURANT"
                },
                new IdentityRole
                {
                    Name = "Supplier",
                    NormalizedName = "SUPPLIER"
                }
                );
        }
        public DbSet<HowdyFresh.Models.Supplier> Supplier { get; set; }
        public DbSet<HowdyFresh.Models.Restaurant> Restaurant { get; set; }
        public DbSet<HowdyFresh.Models.Roles> Roles { get; set; }
    }
}
