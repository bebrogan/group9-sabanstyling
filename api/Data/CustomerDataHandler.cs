using System.Collections.Generic;
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
            var values = GetValues(post);
            db.Open();
            db.Update(sql, values);
            db.Close();
        }

        public void Insert(Customer cust)
        {
            string sql = "INSERT INTO customer (Id, Email, FirstName, LastName, Phone, Why, Date)";
            sql += "VALUES (@ID, @Email, @FirstName, @LastName, @Phone, @Why, @Date)";

            var values = GetValues(post);
            db.Open();
            db.Insert(sql, values);
            db.Close();
        }

        public List<Customer> Select()
        {
            List<Customer> myPost = new List<Customer>();

            db.Open();
            string sql = "SELECT * from customer";
            
            List<ExpandoObject> results = db.Select(sql);

            foreach(dynamic item in results)
            {
                Post temp = new Post(){ID = item.id, 
                Email = item.email,
                FirstName = item.FirstName,
                LastName = item.LastName,
                Phone = item.phone,
                Why = item.why,
                Date = item.date};

                myPost.Add(temp);


            }
            

            // db.Close();

            return myPost;
        }

        public void Update(Customer cust)
        {
            string sql = "UPDATE customer SET id=@ID, email=@Email, why = @Why, phone = @Phone, WHERE id=@ID";

            var values = GetValues(post);
            db.Open();
            db.Update(sql, values);
            db.Close();
        }
    }
}