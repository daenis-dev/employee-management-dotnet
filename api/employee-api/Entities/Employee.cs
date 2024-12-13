namespace EmployeeApi.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public decimal Salary { get; set; }

        public int JobTitleId { get; set; }
        public JobTitle JobTitle { get; set; }
    }
}
