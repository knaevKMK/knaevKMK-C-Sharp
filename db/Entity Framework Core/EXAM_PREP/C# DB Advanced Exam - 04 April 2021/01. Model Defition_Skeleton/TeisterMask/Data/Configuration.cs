namespace TeisterMask.Data
{
    public static class Configuration
    {
        public static string ConnectionString = 
            "Server=.\\SQLEXPRESS;" +
            "Database=asda;" +

// Error: does not work with 
      //      "Trusted Connection=True";
                                               
        //"Initial Catalog=AAAA;"+
       "Integrated Security= True";
    }
}
