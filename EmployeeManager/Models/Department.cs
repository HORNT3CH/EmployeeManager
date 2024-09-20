namespace EmployeeManager.Models
{
    public class Department
    {
        public int? DepartmentId { get; set; }
        public string? DepartmentName { get; set; }

        // Navigation property to associate employees
        public ICollection<Employee>? Employees { get; set; }

        // Navigation property to associate department reclass hours
        public ICollection<DepartmentReclass>? DepartmentReclasses { get; set; }
    }

}
