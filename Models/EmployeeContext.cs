using System;
using Microsoft.EntityFrameworkCore;

namespace SimpleCRUD.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions options) : base (options) {}

        public DbSet<Employee> Employees { get; set; }
    
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Employee>().HasData(new Employee 
            {
                Id = 1,
                FirstName = "Patrick",
                LastName = "Boynton",
                Gender = "Male",
                Email = "email@gmail.com",
                DateOfBirth = new DateTime(1981, 01, 07),
                PhoneNumber = "1-555-5555"
            }, new Employee
            {
                Id = 2,
                FirstName = "Jane",
                LastName = "Doe",
                Gender = "Female",
                Email = "email@yahoo.com",
                DateOfBirth = new DateTime(1973, 05, 12),
                PhoneNumber = "1-555-5555"
            }
            );
        }
    }
}