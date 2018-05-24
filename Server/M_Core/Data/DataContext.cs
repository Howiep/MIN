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
        public DbSet<Shift> Shift { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<GroupExperiences> ExperienceGroups { get; set; }
        public DbSet<ShiftExperiences> ShiftExperiences { get; set; }



        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //The many to many cardinality between experience and experience category
            //effectivly creating the join table being like this:
            //Experience - m-1 - ExperienceCategoryExperience - 1-n - ExperienceCategory

            //The main join table has the following keys
            builder.Entity<ExperienceCategoryExperience>()
                .HasKey(ece => new { ece.ExperienceCategoryID, ece.ExperienceID });

            //ExperienceCategoryExperience has one experience 
            builder.Entity<ExperienceCategoryExperience>()
                .HasOne(e => e.Experience)
                .WithMany(ece => ece.ExperienceCategoryExperience)
                .HasForeignKey(e => e.ExperienceID);

            //ExperienceCategoryExperience has one experiencecategory
            builder.Entity<ExperienceCategoryExperience>()
                .HasOne(ec => ec.ExperienceCategory)
                .WithMany(ece => ece.ExperienceCategoryExperience)
                .HasForeignKey(ec => ec.ExperienceCategoryID);


            //The many to many cardinality between experience and group (See above for explaination)
            builder.Entity<GroupExperiences>()
                .HasKey(eg => new { eg.ExperienceID, eg.GroupID });

            builder.Entity<GroupExperiences>()
                .HasOne(e => e.Experience)
                .WithMany(eg => eg.GroupExperiences)
                .HasForeignKey(e => e.ExperienceID);

            builder.Entity<GroupExperiences>()
                .HasOne(e => e.Group)
                .WithMany(eg => eg.GroupExperiences)
                .HasForeignKey(e => e.GroupID);


            //The many to many cardinality between experience and Shift (See above for explaination)
            builder.Entity<ShiftExperiences>()
                .HasKey(we => new { we.ExperienceID, we.ShiftID });

            builder.Entity<ShiftExperiences>()
                .HasOne(e => e.Experience)
                .WithMany(se => se.ShiftExperiences)
                .HasForeignKey(e => e.ExperienceID);

            builder.Entity<ShiftExperiences>()
                .HasOne(s => s.Shift)
                .WithMany(se => se.ShiftExperiences)
                .HasForeignKey(s => s.ShiftID);




            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            //     builder.Entity<ApplicationUser> ()
            //    .HasMany (s => s.Groups);

        }
    }
}
