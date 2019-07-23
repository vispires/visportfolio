using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesDemo.Models;

namespace RazorPagesDemo.Pages
{
    public class CustomerModel : PageModel
    {
        readonly DatabaseContext _Context;
        public CustomerModel(DatabaseContext databasecontext)
        {
            _Context = databasecontext;
        }


        public string WelcomeMessage { get; set; }
            
        [BindProperty]
        public Customer Customer { get; set; }
        public void OnGet()
        {
            WelcomeMessage = "WelCome to Razor Pages by Danny Rivera";
        }

        public ActionResult OnPost()
        {
            var customer = Customer;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            customer.CustomerID = 0;
            var result = _Context.Add(customer);
            _Context.SaveChanges();

            return RedirectToPage("AllCustomer");
        }
    }
}