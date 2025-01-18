using System.ComponentModel.DataAnnotations.Schema;

namespace HRDemo.Api.Entities
{
    public class EmployeeData
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public int DepartmentId { get; set; }

        public int EmployeeStatusId { get; set; }

        public string? EmployeeNumber { get; set; }

        [ForeignKey("DepartmentId")]
        public Department? Department { get; set; }

        [ForeignKey("EmployeeStatusId")]
        public EmployeeStatus? EmployeeStatus { get; set; }
    }
}
