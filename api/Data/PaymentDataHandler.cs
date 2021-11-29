using System.Collections.Generic;
using System.Dynamic;
using api.Interfaces;
using api.Models;

namespace api.Data
{
    public class PaymentDataHandler : IPaymentDataHandler
    {
        private Database db;
        public PaymentDataHandler()
        {
            db = new Database(); 
        }
        public void Delete(Payment pay)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(Payment pay)
        {
            string sql = "INSERT INTO payment (paymentID, cardNum, fullName, CVV, expDate, street, city, state, zip)";
            sql += "VALUES (@paymentID, @cardNum, @fullName, @cvv, @expDate, @street, @city, @state, @zip)";

            var values = GetValues(pay);
            db.Open();
            db.Insert(sql, values);
            db.Close();
        }

        public List<Payment> Select()
        {
            db.Open(); 

            string sql = "SELECT * from payment ORDER BY 'id' desc"; 

            List<ExpandoObject> results = db.Select(sql); 

            List<Payment> pay = new List<Payment>(); 
            foreach(dynamic item in results)
            {
                Payment temp = new Payment()
                {
                    PaymentID = item.paymentID,
                    CardNum = item.cardNum,
                    FullName = item.fullName,
                    CVV = item.CVV,
                    ExpDate = item.expDate,
                    Street = item.street,
                    City = item.city,
                    State = item.state,
                    Zip = item.zip,
                }; 
                pay.Add(temp); 
            }
            db.Close();
            return pay; 
        }

        public void Update(Payment pay)
        {
            string sql = "UPDATE payment SET ";

            var values = GetValues(pay); 
            foreach(var p in values)
            {
                if(p.Key != "ID" && p.Value != null)   
                {
                    switch(p.Key)
                    {
                        case "@cardNum":
                            sql += "cardNum = @cardNum,";
                            break; 
                        case "@fullName":
                            sql += "fullName = @fullName,";
                            break; 
                        case "@cvv":
                            sql += "CVV = @cvv,";
                            break; 
                        case "@expDate":
                            sql += "expDate = @expDate,";
                            break; 
                        case "@street":
                            sql += "street = @street,";
                            break; 
                        case "@city":
                            sql += "city = @city,";
                            break; 
                        case "@state":
                            sql += "state = @state,";
                            break;
                        case "@zip":
                            sql += "zip = @zip,";
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

        public Dictionary<string, object> GetValues(Payment pay)
        {
            var values = new Dictionary<string,object>()
            {
                {"@paymentID", pay.PaymentID},
                {"@cardNum", pay.CardNum},
                {"@fullName", pay.FullName},
                {"@CVV", pay.CVV},
                {"@expDate", pay.ExpDate},
                {"@street", pay.Street},
                {"@city", pay.City},
                {"@state", pay.State},
                {"@zip", pay.Zip},
            }; 
            return values; 
        }
    }
}