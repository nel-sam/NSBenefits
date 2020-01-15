using System.Collections.Generic;
using Models;

namespace Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAll();
    }
}
