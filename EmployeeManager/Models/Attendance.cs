using EmployeeManager.Data;

namespace EmployeeManager.Models
{
    public class Attendance
    {
        public int? AttendanceId { get; set; }

        // Foreign key to Employee
        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; }

        // Attendance status
        public AttendanceStatus Status { get; set; }

        // Date of attendance event
        public DateTime? AttendanceDate { get; set; }

        // Calculated points for the attendance event
        public int? Points => (int)Status;
    }

}
