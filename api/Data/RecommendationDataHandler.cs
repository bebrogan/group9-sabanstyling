using System.Collections.Generic;
using System.Dynamic;
using api.Interfaces;
using api.Models;

namespace api.Data
{
    public class RecommendationDataHandler : IRecommendationDataHandler
    {
        private Database db;
        public RecommendationDataHandler()
        {
            db = new Database(); 
        }
        public void Delete(Recommendation rec)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(Recommendation rec)
        {
            string sql = "INSERT INTO recommendation (recID, customerID, link, employeeID, status, clothingID)";
            sql += "VALUES (@recID, @customerId, @link, @employeeID, @status, @clothingID)";

            var values = GetValues(rec);
            db.Open();
            db.Insert(sql, values);
            db.Close();
        }

        public List<Recommendation> Select()
        {
            db.Open(); 

            string sql = "SELECT * from recommendation ORDER BY 'recID' desc"; 

            List<ExpandoObject> results = db.Select(sql); 

            List<Recommendation> rec = new List<Recommendation>(); 
            foreach(dynamic item in results)
            {
                Recommendation temp = new Recommendation()
                {
                    RecID = item.recID,
                    CustomerID = item.customerID,
                    Link = item.link,
                    EmployeeID = item.employeeID,
                    Status = item.status,
                    ClothingID = item.clothingID,
                }; 
                rec.Add(temp); 
            }
            db.Close();
            return rec; 
        }

        public void Update(Recommendation rec)
        {
            string sql = "UPDATE recommendation SET ";

            var values = GetValues(rec); 
            foreach(var p in values)
            {
                if(p.Key != "ID" && p.Value != null)   
                {
                    switch(p.Key)
                    {
                        case "@recID":
                            sql += "recID = @recID,";
                            break; 
                        case "@customerID":
                            sql += "customerID = @customerID,";
                            break; 
                        case "@link":
                            sql += "link = @link,";
                            break; 
                        case "@employeeID":
                            sql += "employeeID = @employeeID,";
                            break; 
                        case "@status":
                            sql += "status = @status,";
                            break; 
                        case "@clothingID":
                            sql += "clothingID = @clothingID,";
                            break; 
                    }
                }
            }
            sql = sql.Remove(sql.Length - 1, 1);
            sql += " WHERE id=@id"; 
            db.Open(); 
            db.Update(sql, values);
            db.Close();
        }
        public Dictionary<string, object> GetValues(Recommendation rec)
        {
            var values = new Dictionary<string,object>()
            {
                {"@paymentID", rec.RecID},
                {"@cardNum", rec.CustomerID},
                {"@fullName", rec.Link},
                {"@CVV", rec.EmployeeID},
                {"@expDate", rec.Status},
                {"@street", rec.ClothingID},
            }; 
            return values; 
        }
    }
}