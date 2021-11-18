using api.Data;
using api.Interfaces;

namespace api.Models
{
    public class Clothing
    {
        public int ID {get; set;}
        public string Size {get; set;}
        public string Type {get; set;}
        public string Link {get; set;}
        public double Price {get; set;}
        public IClothingDataHandler dataHandler {get; set;}

        public Clothing()
        {
            dataHandler = new ClothingDataHandler(); 
        }
    }
}