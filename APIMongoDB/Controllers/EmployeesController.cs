using APIMongoDB.Models;
using APIMongoDB.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIMongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeesService _employeesServices;
        public EmployeesController(EmployeesService employeesServices) => _employeesServices = employeesServices;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var allemployees = await _employeesServices.GetEmployeesAsync();
            if (allemployees.Any())
            {
                return Ok(allemployees);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{id:length(24)}")]
        public async Task<IActionResult> Get(string id)
        {
            var employees = await _employeesServices.GetEmployeesAsync(id);
            if (employees != null)
            {
                return Ok(employees);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Employees employees)
        {
            await _employeesServices.InsertEmployeesAsync(employees);
            return CreatedAtAction(nameof(Get), new { id = employees.Id }, employees);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> put(string id, Employees employees)
        {
            var employee = await _employeesServices.GetEmployeesAsync(id);
            if (employees != null)
            {
                employees.Id = employee.Id;
                await _employeesServices.UpdateEmployeesAsync(employees);
                return Ok(employees);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var employee = await _employeesServices.GetEmployeesAsync(id);
            if (employee != null)
            {
                await _employeesServices.DeleteEmployeesAsync(id);
                return NoContent();
            }
            else
            {

                return BadRequest();
            }
        }
    }
}

