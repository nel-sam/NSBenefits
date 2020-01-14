using System.Collections.Generic;
using Data;
using Interfaces;

namespace Services
{
  public class EmployeeService: IEmployeeService
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
