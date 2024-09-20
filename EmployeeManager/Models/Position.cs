namespace EmployeeManager.Models
{
    public class Position
    {
        public int? PositionId { get; set; }
        public string? PositionName { get; set; }

        // Navigation property to associate employees
        public ICollection<Employee>? Employees { get; set; }
    }

}
