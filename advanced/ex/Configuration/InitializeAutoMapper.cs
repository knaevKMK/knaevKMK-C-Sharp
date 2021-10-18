
namespace ex.Configuration
{
using AutoMapper;
using System;
    public static class InitializeAutoMapper
    {

        public static void Initialize()
        {
            CreateModelsToViewModels();

            CreateDtoModelsToServiceModels();

            CreateServiceModelsToModels();
        }

        private static void CreateServiceModelsToModels()
        {
            
        }

        private static void CreateDtoModelsToServiceModels()
        {
           
        }

        private static void CreateModelsToViewModels()
        {
           
        }
    }
}
