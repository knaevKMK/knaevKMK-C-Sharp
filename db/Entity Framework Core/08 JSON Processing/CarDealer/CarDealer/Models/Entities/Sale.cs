﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
public    class Sale
    {
        public int Id { get; set; }
        public decimal Discount { get; set; }
        
        public int CarId { get; set; }
        public virtual Car Car { get; set; }
        
        
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
