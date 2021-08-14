using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DtoImport
{
   public class CarImportDto
    {

        public string make { get; set; }
        public string model { get; set; }
        public long travelledDistance { get; set; }
        public ICollection<int> partsId { get; set; }
    }
}
