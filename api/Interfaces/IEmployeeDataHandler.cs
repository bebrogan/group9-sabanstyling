using System.Collections.Generic;
using api.Models;

namespace api.Interfaces
{
    public interface IEmployeeDataHandler
    {
         public List<Employee> Select();
         public void Delete(Employee emp);

         public void Insert(Employee emp);

         public void Update(Employee emp);
    }
}