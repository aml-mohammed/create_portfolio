using Core.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext>options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Owner>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<PortfolioItem>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<MoServices>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Owner>().HasData(
                         new Owner
                         {
                             Id = Guid.NewGuid(),
                             FullName = "mohamed hares",
                             Profile = "mechanical Engineer",
                             Avatar = "IMG-20181108-WA0000.jpg",
                             Contact = "01000283950",
                             Email = "mohamedhares2011@gmail.com",
                             Experience = "7 years",
                             Resume = "cv.pdf"

                         });
        }
        public DbSet<MoServices> MServices { get; set; }
        public DbSet<Owner> Owner { get; set; }
        public DbSet<PortfolioItem> PortfolioItems { get; set; }
      

    }
}
