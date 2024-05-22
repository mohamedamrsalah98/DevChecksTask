using DevChecksTask.Data;
using DevChecksTask.Models;
using DevChecksTask.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace DevChecksTask.Services.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _context;

        public EmployeeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                throw new KeyNotFoundException("Employee not found");
            }
            return employee;
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            ValidateEmployee(employee);
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }

        private void ValidateEmployee(Employee employee)
        {
            var validationContext = new ValidationContext(employee);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(employee, validationContext, validationResults, true);

            if (!isValid)
            {
                var validationErrors = string.Join(", ", validationResults.Select(vr => vr.ErrorMessage));
                throw new ValidationException($"Employee validation failed: {validationErrors}");
            }
        }
    }
}
