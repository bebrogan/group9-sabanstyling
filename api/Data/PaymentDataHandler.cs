using System.Collections.Generic;
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
            throw new System.NotImplementedException();
        }

        public List<Payment> Select()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Payment pay)
        {
            throw new System.NotImplementedException();
        }
    }
}