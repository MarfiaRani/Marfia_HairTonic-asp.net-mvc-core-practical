using Marfia_HairTonic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Marfia_HairTonic.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HairTonicDbContext _context;

        public HomeController(ILogger<HomeController> logger, HairTonicDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public async Task<IActionResult> Products(string searchString,  int? pageNumber)
        {
            // Products retrieving
            ViewData["CurrentFilter"] = searchString;
           


            var products = from p in _context.Products.Include(p => p.Category)
                           select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(p => p.Name.Contains(searchString));

            }


            int pageSize = 10;
            return View(await PaginatedList<Product>.CreateAsync(products.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        public IActionResult Contact_us()
        {
            return View();
        }
        public async Task<IActionResult> Categories(string searchString, int? pageNumber)
        {
            ViewData["CurrentFilter"] = searchString;

            var categories = from c in _context.Categories.Include(c => c.Products)
                             select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower();
                categories = categories.Where(c => c.CategoryName.ToLower().Contains(searchString) || c.Description.ToLower().Contains(searchString));
            }

            int pageSize = 10;
            return View(await PaginatedList<Category>.CreateAsync(categories.AsNoTracking(), pageNumber ?? 1, pageSize));
        }






        public IActionResult Privacy()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
