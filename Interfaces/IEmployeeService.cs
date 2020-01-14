using System.Collections.Generic;
using Data;

namespace Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAll();
    }
}
