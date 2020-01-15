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
            modelBuilder.Entity<Dependent>().HasKey(d => d.EmployeeId);
            modelBuilder.Entity<Employee>().HasMany<Dependent>();

            //modelBuilder.Entity<Employee>().HasData(
            //    new Employee
            //    {
            //        Id = 1,
            //        FirstName = "Jake",
            //        LastName = "Jacobs",
            //        Salary = 2000,
            //        Dependents = new List<Dependent>
            //        {
            //            new Dependent { FirstName = "Anthony", LastName ="Jacobs" },
            //            new Dependent { FirstName = "Margret", LastName ="Jacobs" }
            //        }
            //    }
            //);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = configuration["ConnectionStrings::DefaultConnection"];
            optionsBuilder.UseSqlServer("Server=tcp:nsbenefits.database.windows.net,1433;Initial Catalog=NSBenefits;Persist Security Info=False;User ID=Zachsta18Blague;Password=Gt,u7$T-X}n<^F*b;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}
