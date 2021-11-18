using System.Collections.Generic;
using api.Interfaces;
using api.Models;

namespace api.Data
{
    public class CustomerDataHandler : ICustomerDataHandler
    {
        private Database db;
        public CustomerDataHandler()
        {
            db = new Database(); 
        }
        public void Delete(Customer cust)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(Customer cust)
        {
            throw new System.NotImplementedException();
        }

        public List<Customer> Select()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Customer cust)
        {
            throw new System.NotImplementedException();
        }
    }
}