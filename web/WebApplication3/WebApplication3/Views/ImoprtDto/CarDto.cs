using AutoMapper.Configuration.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Views.ImoprtDto
{
    public class CarDto
    {
        public int Id { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public long travelledDistance { get; set; }
        [NotMapped]
        public int[] partsId { get; set; }
    

    }
}
