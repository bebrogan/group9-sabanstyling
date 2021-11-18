using System.Collections.Generic;
using api.Models;

namespace api.Interfaces
{
    public interface IClothingDataHandler
    {
         public List<Clothing> Select();

         public void Delete(Clothing cloth);

         public void Insert(Clothing cloth);

         public void Update(Clothing cloth);
 
    }
}