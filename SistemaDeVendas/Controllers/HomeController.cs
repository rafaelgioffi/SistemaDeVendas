using Microsoft.AspNetCore.Mvc;
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
