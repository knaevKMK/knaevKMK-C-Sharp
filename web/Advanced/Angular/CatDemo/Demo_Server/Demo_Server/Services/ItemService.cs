using Demo_Server.Data;
using Demo_Server.Data.Model;
using Demo_Server.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_Server.Services
{
    public class ItemService
    {
        private readonly DemoAppDbContext data;

        public ItemService(DemoAppDbContext data)
        {
            this.data = data;
        }

        public async Task<int> Create(ItemAddBindingModel model) {

            var item = new Item {
                Name = model.Name,
               Description= model.Description,
               Price = model.Price
            };

            var result = await  data.Items.AddAsync(item);
           await  data.SaveChangesAsync();
            return result.Entity.Id;
        }

        internal async Task<Item> GetById(int id)
        {

            Item item = await this.data.Items.FindAsync(id);

            return item;
        
        }

        internal async  Task<Item[]> All()
        {
         return  this.data.Items
                .ToArray();

            
        }
    }
}
