namespace Models
{
    public class Dependent: Person
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
