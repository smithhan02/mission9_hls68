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
        private IBookstoreRepository repo;

        public HomeController (IBookstoreRepository temp)
        {
            repo = temp;
        }

        public IActionResult Index()
        {
            var blah = repo.Books.ToList();

            return View(blah);
        }

        
    }
}
