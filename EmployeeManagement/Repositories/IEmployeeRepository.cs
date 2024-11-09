using EmployeeManagement.Model;

namespace EmployeeManagement.Repositories;

public interface IEmployeeRepository
{
    Task<IEnumerable<Employee>> GetAllAsync();
    Task<Employee> GetByIdAsync(int id);
    Task AddEmployeeAsync(Employee employee);
    Task UpdateEmployeeAsync(Employee employeeChanges);
    Task DeleteEmployeeAsync(int id);
}
