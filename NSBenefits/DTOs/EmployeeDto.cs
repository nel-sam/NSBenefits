using System.Collections.Generic;

namespace NSBenefits.DTOs
{
    public class EmployeeDto: PersonDto
    {
        // Decimals (or int * 100) should be used to represent
        // currency, not floats because floats have rounding issues
        public decimal Salary { get; set; }
        public IEnumerable<DependentDto> Dependents { get; set; }
    }
}
