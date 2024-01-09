using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaDeVendas.Models;

namespace SistemaDeVendas.Controllers
{
    public class ComprasController : Controller
    {
        private readonly Context _context;

        public ComprasController(Context context)
        {
            _context = context;
        }

        // GET: Compras
        public async Task<IActionResult> Index()
        {
            var context = _context.Compras.Include(c => c.Cliente).Include(p => p.Produto);
            return View(await context.ToListAsync());
        }


        // GET: Compras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Compras == null)
            {
                return NotFound();
            }

            var compra = await _context.Compras
                .Include(c => c.Cliente)
                .Include(p => p.Produto)
                .FirstOrDefaultAsync(m => m.CompraId == id);
            if (compra == null)
            {
                return NotFound();
            }

            return View(compra);
        }

        // GET: Compras/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteID", "Nome");
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoID", "Nome");
            return View();
        }

        // POST: Compras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompraId,ClienteId,ProdutoId,DataCompra,FormaPagamento")] Compra compra)
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteID", "Nome", compra.ClienteId);
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoID", "Nome", compra.ProdutoId);
            //if (ModelState.IsValid)
            //{
            _context.Add(compra);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            //}
            //ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteID", "Nome", compra.ClienteId);
            //ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoID", "Nome", compra.ProdutoId);
            //return View(compra);
        }

        // GET: Compras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Compras == null)
            {
                return NotFound();
            }

            var compra = await _context.Compras.FindAsync(id);
            if (compra == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteID", "Nome", compra.ClienteId);
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoID", "Nome", compra.ProdutoId);
            return View(compra);
        }

        // POST: Compras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CompraId,ClienteId,ProdutoId,DataCompra,FormaPagamento")] Compra compra)
        {
            if (id != compra.CompraId)
            {
                return NotFound();
            }

            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteID", "Nome", compra.ClienteId);
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoID", "Nome", compra.ProdutoId);
            //if (ModelState.IsValid)
            //{
            try
            {
                _context.Update(compra);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompraExists(compra.CompraId))
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
            //ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteID", "Nome", compra.ClienteId);
            //ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoID", "Nome", compra.ProdutoId);
            //return View(compra);
        }

        // GET: Compras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Compras == null)
            {
                return NotFound();
            }

            var compra = await _context.Compras
                .Include(c => c.Cliente)
                .Include(c => c.Produto)
                .FirstOrDefaultAsync(m => m.CompraId == id);
            if (compra == null)
            {
                return NotFound();
            }

            return View(compra);
        }

        // POST: Compras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Compras == null)
            {
                return Problem("Entity set 'Context.Compras'  is null.");
            }
            var compra = await _context.Compras.FindAsync(id);
            if (compra != null)
            {
                _context.Compras.Remove(compra);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompraExists(int id)
        {
            return (_context.Compras?.Any(e => e.CompraId == id)).GetValueOrDefault();
        }
    }
}
