using M_Data;
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
        public DbSet<ExperienceCategory> ExperienceCategories { get; set; }
        public DbSet<ExperienceCategoryExperience> ExperienceCategoryExperience { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ExperienceCategoryExperience>()
                .HasKey(ece => new { ece.ExperienceCategoryID, ece.ExperienceID });

            builder.Entity<ExperienceCategoryExperience>()
                .HasOne(e => e.Experience)
                .WithMany(ece => ece.ExperienceCategoryExperience)
                .HasForeignKey(e => e.ExperienceID);

            builder.Entity<ExperienceCategoryExperience>()
                .HasOne(e => e.ExperienceCategory)
                .WithMany(ece => ece.ExperienceCategoryExperience)
                .HasForeignKey(e => e.ExperienceCategoryID);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            //     builder.Entity<ApplicationUser> ()
            //    .HasMany (s => s.Groups);

        }
    }
}
