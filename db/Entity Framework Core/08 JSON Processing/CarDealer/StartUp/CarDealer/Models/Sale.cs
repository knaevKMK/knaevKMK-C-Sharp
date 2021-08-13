﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


#nullable disable
namespace CarDealer.Models
{
   public class Sale
    {

        public int Id { get; set; }
        public decimal Discount { get; set; }
        public int CarId { get; set; }
        public Car  Car { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}