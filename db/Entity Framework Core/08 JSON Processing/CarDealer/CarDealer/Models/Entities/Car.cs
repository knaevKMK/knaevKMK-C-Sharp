﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Car
    {
        public Car()
        {
            this.Sales = new HashSet<Sale>();
            this.Parts = new HashSet<Part>();
        }

        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public long TravelledDistance { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
        public virtual ICollection<Part> Parts { get; set; }
    }
}
