using System.Collections.Generic;
using System.Dynamic;
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
            string sql = "UPDATE customer SET deleted= 'Y' WHERE id=@ID";
            var values = GetValues(cust);
            db.Open();
            db.Update(sql, values);
            db.Close();
        }

        public void Insert(Customer cust)
        {
            string sql = "INSERT INTO customer (customerID, email, custfName, custlName, phone, why, date, password)";
            sql += "VALUES (@id, @email, @firstName, @lastName, @phone, @why, @date, @password)";

            var values = GetValues(cust);
            db.Open();
            db.Insert(sql, values);
            db.Close();
        }

        public List<Customer> Select()
        {
            db.Open(); 

            string sql = "SELECT * from customer ORDER BY 'id' desc"; 

            List<ExpandoObject> results = db.Select(sql); 

            List<Customer> cust = new List<Customer>(); 
            foreach(dynamic item in results)
            {
                Customer temp = new Customer()
                {
                    ID = item.id,
                    Email = item.email,
                    FirstName = item.custfName,
                    LastName = item.custlName,
                    Phone = item.phone,
                    Why = item.why,
                    Date = item.date,
                    Password = item.password
                }; 
                cust.Add(temp); 
            }

            db.Close(); 
            return cust;
        }

        public void Update(Customer cust)
        {
            string sql = "UPDATE customer SET ";

            var values = GetValues(cust); 
            foreach(var p in values)
            {
                if(p.Key != "ID" && p.Value != null)   
                {
                    switch(p.Key)
                    {
                        case "@id":
                            sql += "customerID = @id,";
                            break; 
                        case "@email":
                            sql += "email = @email,";
                            break; 
                        case "@firstName":
                            sql += "custfName = @firstName,";
                            break; 
                        case "@lastName":
                            sql += "custlName = @lastName,";
                            break; 
                        case "@phone":
                            sql += "phone = @phone,";
                            break; 
                        case "@why":
                            sql += "why = @why,";
                            break; 
                        case "@date":
                            sql += "date = @date,";
                            break; 
                        case "@password":
                            sql += "password = @password,";
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
        public Dictionary<string, object> GetValues(Customer cust)
        {
            var values = new Dictionary<string,object>()
            {
                {"@id", cust.ID},
                {"@email", cust.Email},
                {"@firstName", cust.FirstName},
                {"@lastName", cust.LastName},
                {"@phone", cust.Phone},
                {"@why", cust.Why},
                {"@date", cust.Date},
                {"@password", cust.Password},
            }; 
            return values; 
        }
    }
}