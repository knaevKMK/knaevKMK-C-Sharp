using CarDealer.Data;
using CarDealer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer
{
  public  class StartUp
    {
        private static CustomerService customerService= new CustomerService();
        private static SupplierService supplierSevice = new SupplierService();
        private static PartService PartService = new PartService();
        private static ApplicationDbContext dbContext= new ApplicationDbContext();
       
        static void Main(string[] args)
        {
            dbContext.Database.EnsureCreated();

            printExercisesOPrions();
            string input = Console.ReadLine();

            while (!input.ToLower().Equals("end"))
            {
                Console.Clear();
                string result = "";
                switch (input)
                {
                    case "1": result = supplierSevice.importFromXml()  ; break;
                    case "2": result = PartService.importFromXml()  ; break;
                    case "3": result = CarService.importFromXml()  ; break;
                    case "4": result = customerService.importFromXml()  ; break;

                    default:
                        result = "Bad Input";
                        break;
                }
                Console.WriteLine(result);
                printExercisesOPrions();
                input = Console.ReadLine();
          }
        }

        private static void printExercisesOPrions()
        {
            Console.WriteLine("\n--------------------------------\n"+
                "\n1. Import Suppliers\n" +
                "2. Import Parts\n" +
                "3. Import Cars\n" +
                "4. Import Customers\n" +
                "5. Import Sales\n"+

                "\n--------------------------------\n" 
                );
        }
    }
}
