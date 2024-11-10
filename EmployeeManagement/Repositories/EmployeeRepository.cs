using EmployeeManagement.Data;
using EmployeeManagement.Model;

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
        throw new NotImplementedException();
    }

    public async Task DeleteEmployeeAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Employee>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Employee> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateEmployeeAsync(Employee employeeChanges)
    {
        throw new NotImplementedException();
    }
}
