

using Data;
using Services;
using System;

namespace Run
{
    class StartUp
    {

    private static ApplicationDbContext db = new ApplicationDbContext();
        private static SupplierService SupplierService = new SupplierService();
        private static PartService PartService = new PartService();
        private static CarService CarService = new CarService();
        private static CustomerService CustomerService = new CustomerService();
        private static SaleService SaleService = new SaleService();
        static void Main(string[] args)
        {

            db.Database.EnsureCreated();
            Console.WriteLine(staticText());
            string input = Console.ReadLine();
            while (!input.ToLower().Equals("end"))
            {
              

                Console.WriteLine(result(input));

                Console.WriteLine(staticText());

                input = Console.ReadLine();
                Console.Clear();
            }
        }

        private static string staticText()
        {
            return "\n"+
                "1. Import Suppliers to DB\n" +
                "2. Import Parts to DB\n" +
                "3. Import Cars to DB\n" +
                "4. Improt Customers to DB\n" +
                "5. IMport Sales to DB\n"+
                "6. Export Ordered Customers\n" +
                "7. Cars from Make Toyota\n" +
                "8. Export Local Suppliers\n" +
                "9. Export Cars with Their List of Parts\n" +
                "10. Export Total Sales by Customer\n" +
                "11. Export Sales with Applied Discount\n";
        }

        private static string result(string input)
        {
            switch (input)
            {

                case "1": return SupplierService.ImportFromJson();
                case "2": return PartService.ImportFromJson();
                case "3": return CarService.ImportFromJson(); ;
                case "4": return CustomerService.ImportFromJson();
                case "5": return SaleService.ImportFromJson();
                case "6": return CustomerService.ExportOrderedCustomers();
                case "7": return CarService.CarsByMake("Toyota");
                case "8": return SupplierService.ExportLocalSuppliers();
                case "9": return CarService.ExportCarsWithTheirParts();
                case "10": return CustomerService.ExportTotalSalesByCustomer();
                case "11": return SaleService.ExportSalesWithAppliedDiscount();
            }
            return "Bad input";
        }
    }
}
