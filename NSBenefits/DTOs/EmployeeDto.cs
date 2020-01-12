using System.Collections.Generic;

namespace NSBenefits.DTOs
{
    public class EmployeeDto: PersonDto
    {
        // Decimals (or ints * 100) should be used to represent
        // currency, not floats because floats have rounding issues
        public decimal Salary { get; set; }
        public List<DependentDto> Dependents { get; set; }
    }
}
