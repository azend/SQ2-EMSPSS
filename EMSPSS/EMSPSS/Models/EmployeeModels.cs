using System;
using System.Data.Entity;

namespace EMSPSS.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class EmployeeDbContext : DbContext
    {
        public DbSet<EmployeeDbContext> Employees { get; set; }
    }
}