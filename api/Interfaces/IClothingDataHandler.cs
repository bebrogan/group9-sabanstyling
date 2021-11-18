using System.Collections.Generic;
using api.Models;

namespace api.Interfaces
{
    public interface IClothingDataHandler
    {
         public List<Clothing> Select();
         public void Delete(Clothing clothing);

         public void Insert(Clothing clothing);

         public void Update(Clothing clothing);
    }
}