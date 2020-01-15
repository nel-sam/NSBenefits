using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models;

namespace Data
{
    public class BenefitsContext: DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Dependent> Dependents { get; set; }

        private IConfiguration configuration { get; }

        public BenefitsContext() {}

        public BenefitsContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    FirstName = "Jake",
                    LastName = "Jacobs",
                    Salary = 2000,
                    Dependents = new List<Dependent>
                    {
                        new Dependent { FirstName = "Anthony", LastName ="Jacobs" },
                        new Dependent { FirstName = "Margret", LastName ="Jacobs" }
                    }
                }
            );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = configuration["ConnectionStrings::DefaultConnection"];
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
