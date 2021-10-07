namespace sell_or_buy.Data.Models.Categories
{
using sell_or_buy.Data.Models.Entities;
    public abstract class VehiclesAndParts:ItemImpl
    {
        public string Cabin { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }

          
    }
}
