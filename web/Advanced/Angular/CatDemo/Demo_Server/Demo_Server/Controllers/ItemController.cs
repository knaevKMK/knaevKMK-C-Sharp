using Demo_Server.Services;
using Demo_Server.Services.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_Server.Controllers
{
    [Route("item/")]
    public class ItemController : ApiController
    {

        private readonly ItemService itemService;

        public ItemController(ItemService itemService)
        {
            this.itemService = itemService;
        }
        [Route("get")]
        public ActionResult Load()
        {
            return Ok("Work ItemController");
        }

        [HttpPost]
        [Route("add")]
        public async Task<ActionResult> Add(ItemAddBindingModel model) {
            if (!ModelState.IsValid)
            {
       //         return BadRequest();
            }    
            try
                {
                      var result = await this.itemService.Create(model);
                      return Ok(result);
                }
                catch (Exception)
                {
                    return BadRequest();
                }
           
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<ActionResult<object>> Get(int id) {
          var result=   await this.itemService.GetById(id);
            if (result==null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<ItemAddBindingModel>> All()
        {
            var result = await this.itemService.All();
            return Ok(result);
        }
    }
}
