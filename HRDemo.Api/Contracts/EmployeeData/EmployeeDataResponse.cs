using HRDemo.Api.Contracts.Department;
using HRDemo.Api.Contracts.EmployeeStatus;

namespace HRDemo.Api.Contracts.EmployeeData
{
    public class EmployeeDataResponse
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public int DepartmentId { get; set; }

        public int EmployeeStatusId { get; set; }

        public string? EmployeeNumber { get; set; }

        public DepartmentResponse? Department { get; set; }

        public EmployeeStatusResponse? EmployeeStatus { get; set; }
    }
}
