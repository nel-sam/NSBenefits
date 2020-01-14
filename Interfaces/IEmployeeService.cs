using System.Collections.Generic;
using Data.Models;

namespace Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAll();
    }
}
