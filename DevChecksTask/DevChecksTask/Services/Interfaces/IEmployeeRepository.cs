using DevChecksTask.Models;


namespace DevChecksTask.Services.Interfaces
{
 

    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task AddEmployeeAsync(Employee employee);
    }

}
