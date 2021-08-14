using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DtoImport
{

    
 public   class CustomerImportDto
    {
        public string name { get; set; }
        public DateTime birhtDate { get; set; }
        public bool isYoungDriver { get; set; }
    }
}
