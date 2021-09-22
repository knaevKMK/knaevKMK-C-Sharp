namespace CarApp.Infrastructure
{
using AutoMapper;
    using CarApp.Data.Models;
    using CarApp.Models.Car;
    using CarApp.Services.Car.Model;


    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Category, CarCategoryServiceModel>();
            this.CreateMap<Car, CarFromModel>()
                .ForMember(c=>c.CategoryId,cfg=>cfg.MapFrom(c=>c.Category.Id));
            //this.CreateMap<Car, LatestCarServiceModel>();
            //this.CreateMap<CarDetailsServiceModel, CarFormModel>();

            //this.CreateMap<Car, CarServiceModel>()
            //    .ForMember(c => c.CategoryName, cfg => cfg.MapFrom(c => c.Category.Name));

            //this.CreateMap<Car, CarDetailsServiceModel>()
            //    .ForMember(c => c.UserId, cfg => cfg.MapFrom(c => c.Dealer.UserId))
            //    .ForMember(c => c.CategoryName, cfg => cfg.MapFrom(c => c.Category.Name));
        }
    }
}
