namespace sell_or_buy.Data.Models.Entities
{
using System;
    public interface IItem
    {
         int Id { get; set; }
         string Title { get; set; }
         decimal Price { get; set; }
         DateTime CreateOn{ get; set; }
         DateTime EndOn{ get; set; }
         bool IsActive { get; set; }


       int CreatorId { get; set; }
        UserApp Creator { get; set; }

  

    }
}
