namespace HRDemo.Api.Database
{
    using Microsoft.EntityFrameworkCore;
    using HRDemo.Api.Entities;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; init; }
        public virtual DbSet<EmployeeData> EmployeeData { get; init; }
        public virtual DbSet<EmployeeStatus> EmployeeStatus { get; init; }
    }
}
