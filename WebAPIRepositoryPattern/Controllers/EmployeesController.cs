using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIRepositoryPattern.Models;
using WebAPIRepositoryPattern.paging;
using WebAPIRepositoryPattern.Repository;

namespace WebAPIRepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees([FromQuery] PagingParameters pagingParameters)
        {
            return await _employeeRepository.GetEmployees(pagingParameters);
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployeeById(int id)
        {
            var employee = _employeeRepository.GetEmployee(id);

            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public ActionResult<Employee> CreateEmployee([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee object is null");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }
            _employeeRepository.CreateEmployee(employee);
            return Ok(CreatedAtRoute("empId", new { id = employee.Id }, employee));
        }

        [HttpPut("{id}")]
        public ActionResult UpdateEmployee(int id,[FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee object is null");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }
            var dbemp = _employeeRepository.GetEmployee(id);

            if (!dbemp.Id.Equals(id)) {
                return NotFound();
            }
            _employeeRepository.UpdateEmployee(employee);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteEmployee(int id)
        {

            var dbemp = _employeeRepository.GetEmployee(id);

            if (!dbemp.Id.Equals(id))
            {
                return NotFound();
            }
            _employeeRepository.Delete(dbemp);
            return NoContent();
        }



    }
}