using DataAccessLayer.Models.Shared;

namespace DataAccessLayer.Models
{
    internal class Employee : BaseEntity
    {
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public string? Address { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime HiringDate { get; set; }
        //Gender => enum[male,female]
        public Gender gender { get; set; }
        //EmployeeType => PartTimeEmployee, FullTimeEmployee
        public EmployeeType employeeType { get; set; }

    }
}
