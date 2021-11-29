using System.Collections.Generic;
using System.Dynamic;
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
            string sql = "UPDATE post SET deleted= 'Y' WHERE clothingID=@ID";
            var values = GetValues(cloth);
            db.Open();
            db.Update(sql, values);
            db.Close();
        }

        public void Insert(Clothing cloth)
        {
            string sql = "INSERT INTO clothing (clothingID, size, type, link, price)";
            sql += "VALUES (@id, @size, @type, @link, @price)";


            var values = GetValues(cloth);
            db.Open();
            db.Insert(sql, values);
            db.Close();
        }

        public List<Clothing> Select()
        {
            db.Open();

            string sql = "SELECT * from clothing";
            
            List<ExpandoObject> results = db.Select(sql);

            List<Clothing> cloth = new List<Clothing>();
            foreach(dynamic item in results)
            {
                Clothing temp = new Clothing()
                {ID = item.clothingID, 
                Size = item.size,
                Type = item.type,
                Link = item.link,
                Price = item.price
                };
                
                cloth.Add(temp);


            }
            db.Close();
            return cloth;
        }

        public void Update(Clothing cloth)
        {
            string sql = "UPDATE clothing SET clothingID=@ID, size=@Size, type=@Type, link = @Link, price = @Price WHERE clothingID=@ID";

            var values = GetValues(cloth);
            db.Open();
            db.Update(sql, values);
            db.Close();
        }
        public Dictionary<string, object> GetValues(Clothing cloth)
        {
            var values = new Dictionary<string,object>()
            {
                {"@id", cloth.ID},
                {"@size", cloth.Size},
                {"@type", cloth.Type},
                {"@link", cloth.Link},
                {"@price", cloth.Price},
            }; 
            return values; 
        }
    }
}