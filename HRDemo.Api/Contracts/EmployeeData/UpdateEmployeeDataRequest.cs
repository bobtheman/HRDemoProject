﻿namespace HRDemo.Api.Contracts.EmployeeData
{
    public class UpdateEmployeeDataRequest
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? EmailAddress { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public int DepartmentId { get; set; }

        public int EmployeeStatusId { get; set; }

        public string? EmployeeNumber { get; set; }
    }
}
