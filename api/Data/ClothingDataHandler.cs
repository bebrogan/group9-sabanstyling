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
            string sql = "UPDATE post SET deleted= 'Y' WHERE id=@Id";
            var values = GetValues(cloth);
            db.Open();
            db.Update(sql, values);
            db.Close();
        }

        public void Insert(Clothing cloth)
        {
            string sql = "INSERT INTO customer (Id, Size, Type, Link, Price)";
            sql += "VALUES (@ID, @Size, @Type, @Link, @Price)";

            var values = GetValues(cloth);
            db.Open();
            db.Insert(sql, values);
            db.Close();
        }

        public List<Clothing> Select()
        {
            tList<Clothing> myClothing = new List<Clothing>();

            db.Open();
            string sql = "SELECT * from clothing";
            
            List<ExpandoObject> results = db.Select(sql);

            foreach(dynamic item in results)
            {
                Post temp = new Post(){ID = item.id, Size = item.size,
                Type = item.type,
                Link = item.link,
                Price = item.price};
                myPost.Add(temp);


            }
            

            // db.Close();

            return myClothing;
        }

        public void Update(Clothing cloth)
        {
            string sql = "UPDATE clothing SET id=@ID, size=@Size, type=@Type, link = @Link, price = @Price WHERE id=@ID";

            var values = GetValues(post);
            db.Open();
            db.Update(sql, values);
            db.Close();
        }
    }
}