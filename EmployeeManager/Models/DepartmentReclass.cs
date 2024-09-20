namespace EmployeeManager.Models
{
    public class DepartmentReclass
    {
        public int? DepartmentReclassId { get; set; }

        // Foreign key to Department
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }

        // Employee who did the reclass
        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; }

        // Reclass hours
        public decimal? ReclassHours { get; set; }

        // Date for reclass hours
        public DateTime? ReclassDate { get; set; }
    }

}
