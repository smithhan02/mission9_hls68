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
        
        public CartModel (IBookstoreRepository temp)
        {
            repo = temp;
        }
     public Basket basket { get; set; }
     public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
        }

        public IActionResult OnPost(int BookId, string returnUrl)
        {
            Books b = repo.Books.FirstOrDefault(x => x.BookId == BookId);
            //different from videos 
            //Books price = repo.Books.FirstOrDefault(x => x.Price == Price);
            // if basket already exists, this will get that one, otherwise it will make a new one 
            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
            // add item to basket 
            basket.AddItem(b, 1);

            // set json file based on the new basket 
            HttpContext.Session.SetJson("basket", basket);


            return RedirectToPage(new { ReturnUrl = returnUrl});
        }
    }
}
