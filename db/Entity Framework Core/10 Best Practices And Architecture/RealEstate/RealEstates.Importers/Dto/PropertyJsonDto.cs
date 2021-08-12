
namespace RealEstates.Importers.Dto
{
    public class PropertyJsonDto
    {
        public string Url { get; set; }

        public int Size { get; set; }
        public int YardSize { get; set; }

        public byte Floor { get; set; }

        public byte TotalFloors { get; set; }

        public string District { get; set; }

        public int Year { get; set; }

        public string PropertyType { get; set; }

        public string BuildingType { get; set; }

        public int Price { get; set; }
    }
}
