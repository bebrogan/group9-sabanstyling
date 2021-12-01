using api.Data;
using api.Interfaces;

namespace api.Models
{
    public class Recommendation
    {
        public int RecID {get; set;}
        public int CustomerID {get; set;}
        public string Link {get; set;}
        public int EmployeeID {get; set;}
        public string Status {get; set;}
        public int ClothingID {get; set;}
        public IRecommendationDataHandler dataHandler {get; set;}

        public Recommendation()
        {
            dataHandler = new RecommendationDataHandler(); 
        }
    }
}