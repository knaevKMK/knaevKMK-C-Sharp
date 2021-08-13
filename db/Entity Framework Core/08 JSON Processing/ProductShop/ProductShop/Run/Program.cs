using Data;
using Services;
using Services.interfaces;
using System;

namespace Run
{
    class Program
    {
        private static string USER_FILE_PATH = "./../../../../Resourses/ReadJson/users.json";
        private static string CATEGORY_FILE_PATH = "./../../../../Resourses/ReadJson/categories.json";
        private static string PRODUCT_FILE_PATH = "./../../../../Resourses/ReadJson/products.json";
        private static string CATEGORY_PRODUCT_FILE_PATH = "";

       



        private static IUserService UserService= new UserService();
        private static ICategoryService CategoryService = new CategoryService();
        private static IProductService ProductService = new ProductService();
        static void Main(string[] args)
        {
            Console.WriteLine("Check DataBase");
            var db = new ApplicationDbContext();
            if (!db.Database.CanConnect())
            {
            db.Database.EnsureCreated();
            Console.WriteLine("Create DataBase");

            }
            Console.WriteLine(exercises());
            string input = Console.ReadLine();

            while (!input.ToLower().Equals("end"))
            {
                Console.Clear();
                Console.WriteLine(result(input));
                Console.WriteLine(exercises());
                input = Console.ReadLine();
              
            }
        }

        private static string exercises()
        {
            return "\n1. Improt users from file\n" +
                 "2. Import categories from file\n" +
                 "3. Import products from file\n" +
                 "4. Export Products with price in range\n";
        }

        private static string result(string input)
        {
            switch (input)
            {
                case "1": return UserService.ImportFromFile(USER_FILE_PATH);
                case "2": return CategoryService.LoadFromJson(CATEGORY_FILE_PATH); 
                case "3": return ProductService.LoadFromJson(PRODUCT_FILE_PATH); 
                case "4": return ProductService.ExportProductInRange(500,1000);
                case "5": 
                case "6": 
                case "7": return "";
            }
            return "bad input";
        }
    }
}

