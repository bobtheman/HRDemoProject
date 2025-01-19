namespace HRDemo.Api.Contracts.EmployeeData
{
    public class CreateEmployeeDataRequest
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? EmailAddress { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public int DepartmentId { get; set; }

        public int EmployeeStatusId { get; set; }

        public string? EmployeeNumber { get; set; }
    }
}
