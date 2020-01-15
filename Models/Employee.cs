using System.Collections.Generic;

namespace Models
{
  public class Employee: Person
    {
        public decimal Salary { get; set; }
        public ICollection<Dependent> Dependents { get; set; }
    }
}
