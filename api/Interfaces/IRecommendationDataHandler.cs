using System.Collections.Generic;
using api.Models;

namespace api.Interfaces
{
    public interface IRecommendationDataHandler
    {
         public List<Recommendation> Select();
         public void Delete(Recommendation rec);

         public void Insert(Recommendation rec);

         public void Update(Recommendation rec);
    }
}