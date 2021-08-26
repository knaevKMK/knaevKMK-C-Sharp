using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class IndexModel
    {
       [BindProperty(SupportsGet =true)]
        public string  Name { get; set; }
    }
}
