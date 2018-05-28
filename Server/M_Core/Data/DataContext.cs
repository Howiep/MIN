using M_Data.models;
using M_Data.Models;
using M_Data.Models.InternshipLocation;
using M_Data.Models.Shift;
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
        public DbSet<ExperienceGroup> ExperienceGroups { get; set; }
        public DbSet<ExperienceGroupRelation> ExperienceGroupRelations { get; set; }


        public DbSet<InternshipLocation> InternShipLocations { get; set; }
        public DbSet<Child> Children { get; set; }

        public DbSet<Shift> Shifts { get; set; }
        public DbSet<ShiftExperiencesRelation> ShiftExperiencesRelations { get; set; }

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
            builder.Entity<ShiftExperiencesRelation>()
            .HasKey(c => new { c.ExperienceId, c.ShiftId });

            builder.Entity<ExperienceGroupRelation>()
            .HasKey(c => new { c.ExperienceId, c.ExperienceGroupId });

            //builder.Entity<ExperienceGroup>()
            //       .HasMany(g => g.Experiences)
            //       .WithOne(s => s.ExperienceGroup)
            //       .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<ExperienceCategory>()
                   .HasMany(g => g.Experiences)
                   .WithOne(s => s.ExperienceCategory)
                   .OnDelete(DeleteBehavior.SetNull);

            //builder.Entity<Experience>()
            //       .HasOne(s => s.ExperienceCategory)
            //       .WithMany(g => g.Experiences)
            //       .HasForeignKey(s => s.ExperienceCategoryId)
            //       .OnDelete(DeleteBehavior.SetNull);

            //builder.Entity<Experience>()
                   //.HasOne(s => s.ExperienceGroup)
                   //.WithMany(g => g.Experiences)
                   //.HasForeignKey(s => s.ExperienceGroupId)
                   //.OnDelete(DeleteBehavior.SetNull);
        }
    }
}
