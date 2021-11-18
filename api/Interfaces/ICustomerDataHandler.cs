using System.Collections.Generic;
using api.Models;

namespace api.Interfaces
{
    public interface ICustomerDataHandler
    {
         public List<Customer> Select();
         public void Delete(Customer cust);

         public void Insert(Customer cust);

         public void Update(Customer cust);
    }
}