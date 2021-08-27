using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Pages
{
    public class AddAddressModel : PageModel
    {
    



        [BindProperty]
        public Address Address { get; set; }
        
        
        public void OnGet()
        {
            if (Address==null)
            {
                Address = new Address
                {
                    Street = "",
                    Town = "",
                    PostCode = ""
                };
            }
        }

        public IActionResult OnPost(Address address)
        {
            //TODO validate
          

            return RedirectToPage("/Index", new  { address.Town});
        }
    }
}
