using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleCRUD.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string FirstName { get; set; }
        [StringLength(100)]
        public string LastName { get; set; }
        [StringLength(6)]
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        [StringLength(10)]
        public string PhoneNumber { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
    }
}