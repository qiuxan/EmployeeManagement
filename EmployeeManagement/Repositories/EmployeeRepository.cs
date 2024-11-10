using EmployeeManagement.Data;
using EmployeeManagement.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly AppDbContext _context;
    public EmployeeRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task AddEmployeeAsync(Employee employee)
    {
        await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync();

    }

    public async Task DeleteEmployeeAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Employee>> GetAllAsync()
    {
        return await _context.Employees.ToListAsync();

    }

    public async Task<Employee?> GetByIdAsync(int id)
    {
        return await _context.Employees.FindAsync(id);
    }

    public async Task UpdateEmployeeAsync(Employee employeeChanges)
    {
        throw new NotImplementedException();
    }
}
