namespace EmployeeManager.Models
{
    public class JobRotation
    {
        public int? JobRotationId { get; set; }

        // Foreign key to Employee
        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; }

        // Details of the rotation
        public string? JobRole { get; set; }
        public DateTime? RotationStartDate { get; set; }
        public DateTime? RotationEndDate { get; set; }

        // Shift information
        public string? Shift { get; set; } // Shift during this rotation
    }

}
