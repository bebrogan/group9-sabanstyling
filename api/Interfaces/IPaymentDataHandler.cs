using System.Collections.Generic;
using api.Models;

namespace api.Interfaces
{
    public interface IPaymentDataHandler
    {
         public List<Payment> Select();
         public void Delete(Payment pay);

         public void Insert(Payment pay);

         public void Update(Payment pay);
    }
}