using System.Collections.Generic;
using api.Interfaces;
using api.Models;

namespace api.Data
{
    public class ClothingDataHandler : IClothingDataHandler
    {
        private Database db;
        public ClothingDataHandler()
        {
            db = new Database(); 
        }
        public void Delete(Clothing cloth)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(Clothing cloth)
        {
            throw new System.NotImplementedException();
        }

        public List<Clothing> Select()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Clothing cloth)
        {
            throw new System.NotImplementedException();
        }
    }
}