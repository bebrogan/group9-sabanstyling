using System;
using api.Data;
using api.Interfaces;

namespace api.Models
{
    public class Customer
    {
        public int ID {get; set;}
        public string Email {get; set;}
        public string FirstName{ get; set;}
        public string LastName{get; set;}
        public int Phone {get; set;}
        public string Why {get; set;}
        public string Password {get; set;}
        public ICustomerDataHandler dataHandler {get; set;}

        public Customer()
        {
            dataHandler = new CustomerDataHandler(); 
        }

    }
}
