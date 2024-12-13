using System.Collections.Generic;
using EmployeeUI.Models;

public class EmployeeService
{
    public EmployeeService()
    {
    }

    public async Task<List<Employee>> GetEmployeesAsync()
    {
        return new List<Employee>
        {
            new Employee
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Salary = 50000.00m,
                JobTitleName = "Software Engineer"
            },
            new Employee
            {
                Id = 2,
                FirstName = "Jane",
                LastName = "Smith",
                Salary = 60000.00m,
                JobTitleName = "Project Manager"
            },
            new Employee
            {
                Id = 3,
                FirstName = "Bob",
                LastName = "Dillon",
                Salary = 90000.00m,
                JobTitleName = "Software Engineer"
            },
            new Employee
            {
                Id = 4,
                FirstName = "Bill",
                LastName = "Smith",
                Salary = 80000.00m,
                JobTitleName = "Software Engineer"
            },
            new Employee
            {
                Id = 5,
                FirstName = "Jill",
                LastName = "Bob",
                Salary = 50000.00m,
                JobTitleName = "Software Engineer"
            },
            new Employee
            {
                Id = 6,
                FirstName = "Same",
                LastName = "Jith",
                Salary = 60000.00m,
                JobTitleName = "Project Manager"
            },
            new Employee
            {
                Id = 7,
                FirstName = "Jane",
                LastName = "Smith",
                Salary = 60000.00m,
                JobTitleName = "Project Manager"
            },
            new Employee
            {
                Id = 8,
                FirstName = "Bob",
                LastName = "Dillon",
                Salary = 90000.00m,
                JobTitleName = "Software Engineer"
            },
            new Employee
            {
                Id = 9,
                FirstName = "Bill",
                LastName = "Smith",
                Salary = 80000.00m,
                JobTitleName = "Software Engineer"
            }
        };
    }
}