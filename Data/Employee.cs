using System.Collections.Generic;

namespace Data
{
  public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public List<Dependent> Dependents { get; set; }
    }
}
