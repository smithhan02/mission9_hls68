using Microsoft.AspNetCore.Mvc;
using mission9_hls68.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission9_hls68.Components
{
    public class TypesViewComponent : ViewComponent
    {
        private IBookstoreRepository repo { get; set; }
        
        public TypesViewComponent (IBookstoreRepository temp)
        { repo = temp;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["Category"];

            var types = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);
            return View(types);
        }
    }
}
