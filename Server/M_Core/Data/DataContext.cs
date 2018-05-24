using M_Data.models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M_Core.Data
{

    public class DataContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Experience> Experiences { get; set; }
        public DbSet<ExperienceGroup> ExperienceGroups { get; set; }
        public DbSet<ExperienceCategory> ExperienceCategories { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            //     builder.Entity<ApplicationUser> ()
            //    .HasMany (s => s.Groups);

            // seeding https://docs.microsoft.com/en-us/ef/core/modeling/data-seeding
            // builder.Entity<Blog>().HasData(new Blog {BlogId = 1, Url = "http://sample.com"});
            // builder.Entity<Post>().HasData(
            // new {BlogId = 1, PostId = 1, Title = "First post", Content = "Test 1"},
            // new {BlogId = 1, PostId = 2, Title = "Second post", Content = "Test 2"});

        }
    }
}
