using System.Collections.Generic;
using Models;

namespace Interfaces
{
  public interface IEmployeeRepo
  {
      IEnumerable<Employee> GetAll();
  }
}
