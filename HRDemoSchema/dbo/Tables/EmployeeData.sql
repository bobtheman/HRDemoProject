CREATE TABLE [dbo].[EmployeeData]
(
	Id INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    EmailAddress NVARCHAR(250) NOT NULL,
    DateOfBirth DATETIME NOT NULL,
    DepartmentId INT NOT NULL,
    EmployeeStatusId INT NOT NULL,
    EmployeeNumber NVARCHAR(50) NOT NULL,
    CONSTRAINT FK_Employees_Department FOREIGN KEY (DepartmentId) REFERENCES Departments(Id),
    CONSTRAINT FK_Employees_EmployeeStatus FOREIGN KEY (EmployeeStatusId) REFERENCES EmployeeStatus(Id)
);
