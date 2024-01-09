using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDeVendas.Models;
using System.Diagnostics;

namespace SistemaDeVendas.Controllers
{
    public class HomeController : Controller
    {
        private readonly Context _context;
        //private readonly ILogger<HomeController> _logger;
        public HomeController(Context context)
        {
            _context = context;
        }

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            ViewData["TotalClientes"] = _context.Clientes.Count();
            ViewData["TotalVendas"] = _context.Compras.Count();
            ViewData["TotalProdutos"] = _context.Produtos.Count();
            
            return View();
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