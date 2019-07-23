using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesDemo.Models;
using System.Collections.Generic;
using System.Linq;

namespace RazorPagesDemo.Pages
{
    public class AllCustomerModel : PageModel
    {
        DatabaseContext _Context;
        public AllCustomerModel(DatabaseContext databasecontext)
        {
            _Context = databasecontext;
        }

        public List<Customer> CustomerList { get; set; }

        public void OnGet()
        {
            var data = (from customerlist in _Context.CustomerTB
                        select customerlist).ToList();

            CustomerList = data;
        }

        public ActionResult OnGetDelete(int? id)
        {
            if (id != null)
            {
                var data = (from customer in _Context.CustomerTB
                            where customer.CustomerID == id
                            select customer).SingleOrDefault();

                _Context.Remove(data);
                _Context.SaveChanges();
            }
            return RedirectToPage("AllCustomer");
        }
    }
}