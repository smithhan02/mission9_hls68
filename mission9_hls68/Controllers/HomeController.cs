using Microsoft.AspNetCore.Mvc;
using mission9_hls68.Models;
using mission9_hls68.Models.ViewModels;
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

        public IActionResult Index(string Category, int pageNum = 1)
        {
            int pageSize = 10;

            var x = new BooksViewModel
            {
                Books = repo.Books
                .Where(b => b.Category == Category || Category == null )
                .OrderBy(b => b.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBooks = (Category == null? 
                    repo.Books.Count() :
                    repo.Books.Where(x => x.Category == Category).Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

           

            return View(x);
        }

        
    }
}
