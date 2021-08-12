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
        private static ICategoryService  CategoryService    = new CategoryService();
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


            Console.WriteLine(UserService.ImportFromFile(USER_FILE_PATH));
              Console.WriteLine(CategoryService.LoadFromJson(CATEGORY_FILE_PATH));
            Console.WriteLine(ProductService.LoadFromJson(PRODUCT_FILE_PATH));
            
        }
    }
}
