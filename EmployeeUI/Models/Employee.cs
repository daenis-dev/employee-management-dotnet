using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeUI.Models
{
    public class Employee
    {
        public required int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required decimal Salary { get; set; }
        public required string JobTitleName { get; set; }
    }
}
