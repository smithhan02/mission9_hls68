using Microsoft.AspNetCore.Mvc;
using mission9_hls68.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission9_hls68.Controllers
{
    public class HomeController : Controller
    {
        private BookstoreContext context { get; set; }

        public HomeController (BookstoreContext temp)
        {
            context = temp;
        }

        public IActionResult Index()
        {
            var blah = context.Books.ToList();

            return View();
        }

        
    }
}
