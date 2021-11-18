using System.Collections.Generic;
using api.Models;

namespace api.Interfaces
{
    public interface IClothingDataHandler
    {
         public List<Clothing> Select();
         public void Delete(Clothing cust);

         public void Insert(Clothing cust);

         public void Update(Clothing cust);
    }
}