﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DtoImport
{
    public class PartImportDto
    {
        
        public string name { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }
        public int supplierId { get; set; }

    }
}
