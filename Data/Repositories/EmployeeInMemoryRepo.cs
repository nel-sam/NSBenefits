using System.Collections.Generic;
using Interfaces;
using Models;

namespace Data.Repositories
{
  public class EmployeeInMemoryRepo : IEmployeeRepo
  {
    public IEnumerable<Employee> GetAll()
    {
      return new List<Employee>
      {
        new Employee
        {
          FirstName = "Bob",
          LastName = "Smith",
          Salary = 2000,
          Dependents = new List<Dependent>
          {
            new Dependent
            {
              FirstName = "Andy",
              LastName = "Smith"
            },
            new Dependent
            {
              FirstName = "Robert",
              LastName = "Smith"
            }
          }
        },
        new Employee
        {
          FirstName = "Aaron",
          LastName = "Thompson",
          Salary = 2000,
          Dependents = new List<Dependent>
          {
            new Dependent
            {
              FirstName = "Mary",
              LastName = "Thompson"
            }
          }
        }
      };
    }
  }
}
