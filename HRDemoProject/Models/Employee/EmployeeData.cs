namespace HRDemoProject.Models.Employee
{
    using HRDemoProject.Models.Department;
    using HRDemoProject.Models.EmployeeStatus;

    public class EmployeeData
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? EmailAddress { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public int DepartmentId { get; set; }

        public int EmployeeStatusId { get; set; }

        public string? EmployeeNumber { get; set; }

        public DepartmentData? Department { get; set; }

        public EmployeeStatusData? EmployeeStatus { get; set; }
    }
}
