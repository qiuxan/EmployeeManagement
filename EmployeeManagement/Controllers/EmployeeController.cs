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

    [HttpPost]
    public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
    {
        await _employeeRepository.AddEmployeeAsync(employee);
        return Created();

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

    [HttpGet]
    public async Task<IEnumerable<Employee>> GetEmployees()
    {
        return await _employeeRepository.GetAllAsync();
    }
}
