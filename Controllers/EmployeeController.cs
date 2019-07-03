using Microsoft.AspNetCore.Mvc;
using SimpleCRUD.Models;
using SimpleCRUD.Models.Repository;

namespace SimpleCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IDataRepository<Employee> _dataRepository;
        public EmployeeController(IDataRepository<Employee> dataRepository)
        {
            _dataRepository = dataRepository;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var employees = _dataRepository.GetAll();

            return Ok(employees);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var employee = _dataRepository.Get(id);

            if(employee == null)
                return NotFound("The employee record couldn't be found.");

            return Ok(employee);
        }

        [HttpPost("new")]
        public IActionResult Post(Employee employee)
        {
            if(employee == null)
                return BadRequest("Employee doesn't exist.");
            
            _dataRepository.Add(employee);
            // Created at route is buggy.
            return CreatedAtAction("Get", new { Id = employee.Id }, employee);
        }

        [HttpPut("update/{id}")]
        public IActionResult Update(int id, [FromBody] Employee employee)
        {

            var employeeToUpdate = _dataRepository.Get(id);

            if(employee == null)
                return BadRequest("Employee doesn't exist.");
            

            _dataRepository.Update(employeeToUpdate, employee);
            // TODO find a better way of handling this.
            return NoContent();
        }


        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var employee = _dataRepository.Get(id);
            
            if(employee == null)
                return NotFound("This employee record does not exist.");

            _dataRepository.Delete(employee);
            
            return NoContent();
        }
    }
}