using RealEstate.Data;
using RealEstates.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstates.Services
{
    public class PropertyService : IPropertyService
    {

        private readonly ApplicationDBContext applicationDBContext;

        public PropertyService(ApplicationDBContext applicationDBContext)
        {
           this.applicationDBContext = applicationDBContext;
        }
        public void Add(Property property)
        {
            this.applicationDBContext.Properties.Add(property);
            this.applicationDBContext.SaveChanges();
        }
    }
}
