using System.Collections.Generic;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Data.Repositories
{
  public class EmployeeRepo : IEmployeeRepo
  {
      private BenefitsContext benefitsContext;

      public EmployeeRepo(BenefitsContext benefitsContext)
        => this.benefitsContext = benefitsContext;

    public IEnumerable<Employee> GetAll()
    {
      return this.benefitsContext.Employees
                .Include(e => e.Dependents);
    }

    public void Create(Employee employee)
    {
      this.benefitsContext.Employees.Add(employee);
      this.benefitsContext.SaveChanges();
    }
  }
}
