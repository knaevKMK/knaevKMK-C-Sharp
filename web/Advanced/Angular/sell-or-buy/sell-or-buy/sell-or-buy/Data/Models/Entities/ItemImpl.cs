namespace sell_or_buy.Data.Models.Entities
{
using System;
    public abstract class ItemImpl : IItem
     {
        public int Id { get; set; }
        public string Title { get; set ; }
        public decimal Price { get ; set ; }
        public DateTime CreateOn { get; set ; }
        public DateTime EndOn { get ; set ; }
        public bool IsActive { get ; set ; }


        public int CreatorId { get ; set ; }
        public UserApp Creator { get; set; }
    }
}
