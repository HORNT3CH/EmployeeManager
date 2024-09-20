namespace EmployeeManager.Models
{
    public class Employee
    {
        public int? EmployeeId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        // Foreign keys for Department and Position
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }

        public int? PositionId { get; set; }
        public Position? Position { get; set; }

        // Work hours and shift
        public decimal? HoursWorked { get; set; }
        public DateTime? WorkDate { get; set; }

        // Shift information
        public string? Shift { get; set; }

        // Navigation property for job rotations
        public ICollection<JobRotation>? JobRotations { get; set; }

        // Navigation property for attendance records
        public ICollection<Attendance>? Attendances { get; set; }
    }


}
