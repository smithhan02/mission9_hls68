using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using mission9_hls68.Infrastructure;
using mission9_hls68.Models;

namespace mission9_hls68.Pages
{
    public class CartModel : PageModel
    {
        private IBookstoreRepository repo { get; set; }
        
        public CartModel (IBookstoreRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }

         public Basket basket { get; set; }
         public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            //basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
        }

        public IActionResult OnPost(int BookId, string returnUrl)
        {
            Books b = repo.Books.FirstOrDefault(x => x.BookId == BookId);
            

            // add item to basket 
            basket.AddItem(b, 1);

            return RedirectToPage(new { ReturnUrl = returnUrl});
        }
        public IActionResult OnPostRemove(int BookId, string returnUrl)
        {
            basket.RemoveItem(basket.Items.First(x => x.Books.BookId == BookId).Books);
            return RedirectToPage( new {ReturnUrl = returnUrl});
        }
    }
}
