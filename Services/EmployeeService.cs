using System.Collections.Generic;
using Interfaces;
using Models;

namespace Services
{
  public class EmployeeService: IEmployeeService
  {
    private IEmployeeRepo employeeRepo;

    public EmployeeService(IEmployeeRepo employeeRepo)
    {
      this.employeeRepo = employeeRepo;
    }

    public IEnumerable<Employee> GetAll()
    {
      return this.employeeRepo.GetAll();
    }
  }
}
