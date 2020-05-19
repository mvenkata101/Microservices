using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeadService.DBContexts
{
    public class LeadContext : DbContext
    {
        public LeadContext(DbContextOptions<LeadContext> options) : base(options)
        {

        }

        public DbSet<Lead> Leads { get; set; }
        public DbSet<LeadStatus> LeadStatuses { get; set; }
        public DbSet<LeadType> LeadTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LeadStatus>().HasData (
                new LeadStatus
                {
                    Id = 1,
                    Name = "New",
                    Description = "New Lead"
                },
                new LeadStatus
                {
                    Id = 2,
                    Name = "Working",
                    Description = "In-progress"
                },
                new LeadStatus
                {
                    Id = 3,
                    Name = "Completed",
                    Description = "Completed"
                },
                new LeadStatus
                {
                    Id =4,
                    Name = "Dead",
                    Description = "Closed"
                }
            );

            modelBuilder.Entity<LeadType>().HasData(
                new LeadType
                {
                    Id = 1,
                    Name = "Internet",
                    Description = "Internet Lead"
                },
                new LeadType
                {
                    Id = 2,
                    Name = "Showroom",
                    Description = "Showroom"
                },
                new LeadType
                {
                    Id = 3,
                    Name = "Phone",
                    Description = "Phone"
                }
            );
        }

    }

    
}
