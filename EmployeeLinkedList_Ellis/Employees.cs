using CsvHelper.Configuration.Attributes;
using LINQtoCSV;

namespace EmployeeLinkedList_Ellis
{
    public class Employees
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }

        [Name("Gender")]
        public string Gender { get; set; }

        [Name("Salary")]
        public decimal Salary { get; set; }

        [Name("Department")]
        public string Department { get; set; }

        public Employees(string lastname, string firstname, string gender, decimal salary, string department)
        {
            LastName = lastname;
            FirstName = firstname;
            Gender = gender;
            Salary = salary;
            Department = department;
        }
    }
}