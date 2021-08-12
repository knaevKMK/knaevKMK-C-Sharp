using CarDealer.Data;
using System;
using System.Linq;

namespace CarDealer
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start Up Now......");
            var dbContext = new CarDealerDBContext();
          //  Console.WriteLine(dbContext.Parts.FirstOrDefault(x => x.Id == 0));
        }
    }
}
