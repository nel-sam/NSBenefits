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

        public BenefitsContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasMany<Dependent>(e => e.Dependents)
                .WithOne(d => d.Employee);

          modelBuilder.Entity<Employee>().HasData(
               new Employee
               {
                   Id = 1,
                   FirstName = "Jake",
                   LastName = "Jacobs",
                   Salary = 2000
               }
            );

            modelBuilder.Entity<Dependent>().HasData(
                new Dependent { Id = 1, FirstName = "Anthony", LastName ="Jacobs", EmployeeId = 1 }
            );

            modelBuilder.Entity<Dependent>().HasData(
                new Dependent { Id = 2, FirstName = "Margret", LastName ="Jacobs", EmployeeId = 1 }
            );


          modelBuilder.Entity<Employee>().HasData(
               new Employee
               {
                   Id = 2,
                   FirstName = "Adam",
                   LastName = "Smith",
                   Salary = 2000
               }
            );

            modelBuilder.Entity<Dependent>().HasData(
                new Dependent { Id = 3, FirstName = "Mike", LastName ="Smith", EmployeeId = 2 }
            );

            modelBuilder.Entity<Dependent>().HasData(
                new Dependent { Id = 4, FirstName = "Adam", LastName ="Smith Jr", EmployeeId = 2 }
            );

            modelBuilder.Entity<Employee>().HasData(
               new Employee
               {
                   Id = 3,
                   FirstName = "Sam",
                   LastName = "Samson",
                   Salary = 2000
               }
            );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
