using api.Data;
using api.Interfaces;

namespace api.Models
{
    public class Payment
    {
        public int PaymentID{get;set;}
        public int CardNum{get;set;}
        public string FullName{get;set;}
        public int CVV{get;set;}
        public int ExpDate{get;set;} 
        public string Street{get;set;}
        public string City{get;set;}
        public string State{get;set;}
        public int Zip{get;set;}
        public IPaymentDataHandler dataHandler {get; set;}

        public Payment()
        {
            dataHandler = new PaymentDataHandler(); 
        }
    

    }
}