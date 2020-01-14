using Data.Models;

namespace NSBenefits.DTOs
{
    public class DependentDto: PersonDto
    {
        public DependentType DependentType { get; set; }
    }
}
