using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sell_or_buy.Data.Models.Entities
{
    public class UserApp
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string UserId { get; set; }

        public IEnumerable<int> ItemIds { get; set; }
    }
}
