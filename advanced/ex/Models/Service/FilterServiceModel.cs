using ex.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ex.Models.Service
{
    public class FilterServiceModel
    {
        public bool IsSorted { get; set; }
        public List<UserViewModel> users { get; set; }
    }
}
