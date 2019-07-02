using System.Collections.Generic;
using System.Linq;
using SimpleCRUD.Models.Repository;

namespace SimpleCRUD.Models.DataManager
{
    public class EmployeeManager : IDataRepository<Employee>
    {
        private readonly EmployeeContext _employeeContext;
        public EmployeeManager(EmployeeContext context)
        {
            _employeeContext = context;
        }
        public void Add(Employee entity)
        {
            _employeeContext.Employees.Add(entity);
            _employeeContext.SaveChanges();
        }

        public void Delete(Employee entity)
        {
            _employeeContext.Employees.Remove(entity);
            _employeeContext.SaveChanges();
        }

        public Employee Get(int id)
        {
            var employee = _employeeContext.Employees.FirstOrDefault(e => e.Id == id);

            return employee;
        }

        public IEnumerable<Employee> GetAll()
        {
            var employeeList = _employeeContext.Employees.ToList();

            return employeeList;
        }

        public void Update(Employee employee, Employee entity)
        {
            employee.FirstName = entity.FirstName;
            employee.LastName = entity.LastName;
            employee.Gender = entity.Gender;
            employee.Email = entity.Email;
            employee.DateOfBirth = entity.DateOfBirth;
            employee.PhoneNumber = entity.PhoneNumber;

            _employeeContext.SaveChanges();
        }
    }
}