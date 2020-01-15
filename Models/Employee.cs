using System.Collections.Generic;

namespace Models
{
  public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public IEnumerable<Dependent> Dependents { get; set; }
    }
}
