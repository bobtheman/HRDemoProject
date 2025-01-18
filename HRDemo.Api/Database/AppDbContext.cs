namespace HRDemo.Api.Database
{
    using Microsoft.EntityFrameworkCore;
    using HRDemo.Api.Entities;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Department> Departments { get; init; }
        public DbSet<EmployeeData> EmployeeData { get; init; }
        public DbSet<EmployeeStatus> EmployeeStatus { get; init; }
    }
}
