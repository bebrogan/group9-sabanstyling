using api.Data;
using api.Interfaces;

namespace api.Models
{
    public class Employee
    {
        public int ID {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string Email {get; set;}
        public string Password {get; set;}
        public IEmployeeDataHandler dataHandler {get; set;}

        public Employee()
        {
            dataHandler = new EmployeeDataHandler(); 
        }

    }
}