using System.Collections.Generic;
using EmployeeUI.Models;

public class EmployeeService
{
    // TODO: Inject HttpClient and use API
    private List<Employee> employees;

    public EmployeeService()
    {
        employees = new List<Employee>
        {
            new Employee
            {
                Id = 1,
                FirstName = "Michael",
                LastName = "Scott",
                Salary = 50000.00m,
                JobTitleName = "Manager"
            },
            new Employee
            {
                Id = 2,
                FirstName = "Jim",
                LastName = "Halpert",
                Salary = 60000.00m,
                JobTitleName = "Sales"
            },
            new Employee
            {
                Id = 3,
                FirstName = "Dwight",
                LastName = "Schrute",
                Salary = 30000.00m,
                JobTitleName = "Sales"
            },
            new Employee
            {
                Id = 4,
                FirstName = "Creed",
                LastName = "Bratton",
                Salary = 30000.00m,
                JobTitleName = "Quality Assurance"
            },
            new Employee
            {
                Id = 5,
                FirstName = "Kelly",
                LastName = "Kapore",
                Salary = 20000.00m,
                JobTitleName = "Customer Service"
            },
            new Employee
            {
                Id = 6,
                FirstName = "Holly",
                LastName = "Flax",
                Salary = 70000.00m,
                JobTitleName = "Human Resources"
            },
            new Employee
            {
                Id = 7,
                FirstName = "Toby",
                LastName = "Flenderson",
                Salary = 70000.00m,
                JobTitleName = "Human Resources"
            },
            new Employee
            {
                Id = 8,
                FirstName = "Kevin",
                LastName = "Malone",
                Salary = 20000.00m,
                JobTitleName = "Accountant"
            },
            new Employee
            {
                Id = 9,
                FirstName = "Oscar",
                LastName = "Martinez",
                Salary = 60000.00m,
                JobTitleName = "Accountant"
            },
            new Employee
            {
                Id = 10,
                FirstName = "Angela",
                LastName = "Martin",
                Salary = 40000.00m,
                JobTitleName = "Accountant"
            },
            new Employee
            {
                Id = 11,
                FirstName = "Pam",
                LastName = "Beasly",
                Salary = 15000.00m,
                JobTitleName = "Receptionist"
            },
            new Employee
            {
                Id = 12,
                FirstName = "Erin",
                LastName = "Hannon",
                Salary = 15000.00m,
                JobTitleName = "Receptionist"
            }
        };
    }

    public async Task<List<Employee>> GetEmployeesAsync()
    {
        return employees;
    }

    public async Task CreateEmployeeAsync(Employee employee)
    {
        employees.Add(employee);
    }

    public async Task UpdateEmployeeAsync(Employee updatedEmployee)
    {
        var employee = employees.FirstOrDefault(e => e.Id == updatedEmployee.Id);
        if (employee != null)
        {
            employee.FirstName = updatedEmployee.FirstName;
            employee.LastName = updatedEmployee.LastName;
            employee.Salary = updatedEmployee.Salary;
            employee.JobTitleName = updatedEmployee.JobTitleName;
        }
    }

    public async Task DeleteEmployeeAsync(int employeeId)
    {
        var employee = employees.FirstOrDefault(e => e.Id == employeeId);
        if (employee != null)
        {
            employees.Remove(employee);
        }
    }
}