using EmployeeManagement.Model;
using EmployeeManagement.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController: ControllerBase
{
    private readonly IEmployeeRepository _employeeRepository;
    public EmployeeController(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeeById()
    {
        var allEmployees = await _employeeRepository.GetAllAsync();
        return Ok(allEmployees);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<Employee>> GetEmployeeById(int id)
    {
        var employee = await _employeeRepository.GetByIdAsync(id);
        if (employee is null)
        {
            return NotFound();
        }
        return Ok(employee);
    }

    [HttpPost]
    public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
    {
        await _employeeRepository.AddEmployeeAsync(employee);
        return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id},employee);

        //example of the employee object
        /*
         
         {
          "id": 0,
          "firstName": "johb",
          "lastName": "doe",
          "email": "jd@doe.com",
          "phone": "1234",
          "position": "manager"
          }

         */
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> DeleteEmployeeById(int id)
    {

        await _employeeRepository.DeleteEmployeeAsync(id);

        return NoContent();
    }
}
