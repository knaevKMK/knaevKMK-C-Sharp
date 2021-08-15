
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models.DtoImport
{


    public class CustomerImportDto
    {
        public string name { get; set; }
        public DateTime birthDate { get; set; }
        public bool isYoungDriver { get; set; }
    }
   
}
