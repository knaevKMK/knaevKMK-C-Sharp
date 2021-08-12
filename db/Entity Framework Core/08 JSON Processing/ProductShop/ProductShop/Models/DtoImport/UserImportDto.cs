using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DtoImport
{
  public  class UserImportDto
    {
        
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        public int? age { get; set; }
    }
}
