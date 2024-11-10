﻿using EmployeeManagement.Model;
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
    public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
    {
        var allEmployees = await _employeeRepository.GetAllAsync();
        return Ok(allEmployees);
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


}
