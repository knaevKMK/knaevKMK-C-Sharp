using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DtoImport
{
   public class SaleImportDto
    {

         
        public int carId { get; set; }
        public int customerId { get; set; }
        public decimal discount { get; set; }
    }
}
