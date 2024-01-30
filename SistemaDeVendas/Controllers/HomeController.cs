using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDeVendas.Models;
using System.Diagnostics;

namespace SistemaDeVendas.Controllers
{
    public class HomeController : Controller
    {
        private readonly Context _context;        

        public HomeController(Context context)
        {
            _context = context;
        }        

        public IActionResult Index()
        {
            var CategoriesDates = _context.Categories
                .FromSqlRaw("SELECT DISTINCT(CAST(CreateTime AS DATE)) FROM Categories;")
                .ToList();
            ViewData["CategoriesCreated"] = CategoriesDates;
            ViewData["TotalClients"] = _context.Clients.Count();            
            ViewData["TotalSalles"] = _context.Salles.Count();
            ViewData["TotalProducts"] = _context.Products.Count();

            return View();
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
                
    }
}
