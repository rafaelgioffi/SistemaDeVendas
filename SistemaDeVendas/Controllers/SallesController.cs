using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaDeVendas.Models;

namespace SistemaDeVendas.Controllers
{
    public class SallesController : Controller
    {
        private readonly Context _context;

        public SallesController(Context context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var context = _context.Salles.Include(c => c.Clients).Include(p => p.Products);
            return View(await context.ToListAsync());
        }

        // GET: Salles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Salles == null)
            {
                return NotFound();
            }

            var salles = await _context.Salles
                .Include(c => c.Clients)
                .Include(p => p.Products)
                .FirstOrDefaultAsync(m => m.SalleId == id);
            if (salles == null)
            {
                return NotFound();
            }

            return View(salles);
        }

        // GET: Salles/Create
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientID", "Name");
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductID", "Name");
            return View();
        }

        // POST: Salles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SalleId,ClientId,ProductId,SalleDate,PaymentMethod")] Salles salles)
        {
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientID", "Name", salles.ClientId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductID", "Name", salles.ProductId);
            //if (ModelState.IsValid)
            //{
            salles.SalleDate = DateTime.Now;
            _context.Add(salles);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            //}
            //else
            //{
            //    return View("Error");
            //}
            //ViewData["ClientId"] = new SelectList(_context.Clients, "ClientID", "Name", salles.ClientId);
            //ViewData["ProductId"] = new SelectList(_context.Products, "ProdutoID", "Name", salles.ProductId);
            //return View(salles);
        }

        // GET: Salles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Salles == null)
            {
                return NotFound();
            }

            var salles = await _context.Salles.FindAsync(id);
            if (salles == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientID", "Name", salles.ClientId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProdutoID", "Name", salles.ProductId);
            return View(salles);
        }

        // POST: Salles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SalleId,ClientId,ProductId,DataVenda,FormaPagamento")] Salles salles)
        {
            if (id != salles.SalleId)
            {
                return NotFound();
            }

            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientID", "Name", salles.ClientId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductID", "Name", salles.ProductId);
            //if (ModelState.IsValid)
            //{
            try
            {
                _context.Update(salles);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalleExists(salles.SalleId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
            //}
            //ViewData["ClientId"] = new SelectList(_context.Clients, "ClientID", "Name", salles.ClientId);
            //ViewData["ProductId"] = new SelectList(_context.Products, "ProdutoID", "Name", salles.ProductId);
            //return View(salles);
        }

        // GET: Salles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Salles == null)
            {
                return NotFound();
            }

            var salles = await _context.Salles
                .Include(c => c.Clients)
                .Include(c => c.Products)
                .FirstOrDefaultAsync(m => m.SalleId == id);
            if (salles == null)
            {
                return NotFound();
            }

            return View(salles);
        }

        // POST: Salles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Salles == null)
            {
                return Problem("Entity set 'Context.Salles'  is null.");
            }
            var salles = await _context.Salles.FindAsync(id);
            if (salles != null)
            {
                _context.Salles.Remove(salles);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalleExists(int id)
        {
            return (_context.Salles?.Any(e => e.SalleId == id)).GetValueOrDefault();
        }
    }
}
