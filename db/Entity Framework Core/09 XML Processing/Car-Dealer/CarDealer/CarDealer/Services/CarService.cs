using CarDealer.Data;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CarDealer.Services
{
    public class CarService
    {
            private static ApplicationDbContext dbctx = new ApplicationDbContext();
        public static string importFromXml()
        {
            string result = "Cars DB is not empty";

            Dictionary<int, XElement> cars = new Dictionary<int, XElement>();
            
            List<XElement> xElements = XDocument
                        .Load(Static.Static.READ_DIR_PATH + Static.Static.READ_CAR_PATH)
                        .Root.Elements()
                        .ToList();
            if (dbctx.Cars.Count<Car>() == 0)
            {
                xElements
                       .ForEach(e =>
                       {
                           Car car = new Car
                           {
                               Make = e.Element("make").Value,
                               Model = e.Element("model").Value,
                               TravelledDistance = long.Parse(e.Element("TraveledDistance").Value)
                           };
                           Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Car> _car = dbctx.Cars.Add(car);
                           dbctx.SaveChanges();

                           cars.Add(_car.Entity.Id, e.Element("parts"));
                       });


             


                result = $"Successfully imported {cars.Count} cars from {xElements.Count}";


                foreach (var carId in cars.Keys)
                {

                    List<XAttribute> xAttributes = cars[carId].Elements("partId").Attributes("id").ToList();
                    HashSet<PartCar> partCars = cars[carId].Elements("partId").Attributes("id")
                       .Select(e =>
                       {
                           int partId = int.Parse(e.Value);
                           Part part = dbctx.Parts.Find(partId);

                           PartCar p= new PartCar
                           {
                               Car = dbctx.Cars.Find(carId),
                               CarId = carId,
                               PartId = partId,
                               Part = part
                           };
                    //Console.WriteLine();
                           return p;
                       }).ToHashSet();

                    dbctx.PartCars.AddRange(partCars);
                    dbctx.SaveChanges();
                }

                result += $"\nSuccess import PartCars";

            }
            else {
                return result + "\nDoes NOT insert PartCar db" + "\nDoes NOT insert PartCar db";
            }


            return result;
        }

    }
}
