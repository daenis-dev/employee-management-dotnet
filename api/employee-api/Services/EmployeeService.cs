using Microsoft.EntityFrameworkCore;
using EmployeeApi.Data;
using EmployeeApi.Models;

namespace EmployeeApi.Services
{
    public class EmployeeService
    {
        private readonly AppDbContext _context;

        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<EmployeeDto>> GetAllEmployeesAsync()
        {
            return await _context.Employees
                .Include(e => e.JobTitle) // Include JobTitle data
                .Select(e => new EmployeeDto
                {
                    Id = e.Id,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Salary = e.Salary,
                    JobTitleName = e.JobTitle.Name
                })
                .ToListAsync();
        }
    }
}
