using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using kelly.Areas.Identity.Data;
using kelly.Models;

namespace kelly.Controllers
{
    public class OrderdetailsController : Controller
    {
        private readonly kellyDbContext _context;

        public OrderdetailsController(kellyDbContext context)
        {
            _context = context;
        }

        // GET: Orderdetails
        public async Task<IActionResult> Index()
        {
            var kellyDbContext = _context.Orderdetails.Include(o => o.Order)
                                                      .Include(o => o.Product);
            return View(await kellyDbContext.ToListAsync());
        }

        // GET: Orderdetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Orderdetails == null)
            {
                return NotFound();
            }

            var orderdetails = await _context.Orderdetails
                .Include(o => o.Order)
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.OrderdetailsID == id);
            if (orderdetails == null)
            {
                return NotFound();
            }

            return View(orderdetails);
        }

        // GET: Orderdetails/Create
        public IActionResult Create()
        {
            ViewData["OrderID"] = new SelectList(_context.Order, "OrderID", "OrderID");
            ViewData["ProductID"] = new SelectList(_context.Product, "ProductID", "ProductID");
            return View();
        }

        // POST: Orderdetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderdetailsID,customerName,OrderID,ProductID,ProductPrice,ProductQuantity,Price")] Orderdetails orderdetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderdetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderID"] = new SelectList(_context.Order, "OrderID", "OrderID", orderdetails.OrderID);
            ViewData["ProductID"] = new SelectList(_context.Product, "ProductID", "ProductID", orderdetails.ProductID);
            return View(orderdetails);
        }

        // GET: Orderdetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Orderdetails == null)
            {
                return NotFound();
            }

            var orderdetails = await _context.Orderdetails.FindAsync(id);
            if (orderdetails == null)
            {
                return NotFound();
            }
            ViewData["OrderID"] = new SelectList(_context.Order, "OrderID", "OrderID", orderdetails.OrderID);
            ViewData["ProductID"] = new SelectList(_context.Product, "ProductID", "ProductID", orderdetails.ProductID);
            return View(orderdetails);
        }

        // POST: Orderdetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderdetailsID,customerName,OrderID,ProductID,ProductPrice,ProductQuantity,Price")] Orderdetails orderdetails)
        {
            if (id != orderdetails.OrderdetailsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderdetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderdetailsExists(orderdetails.OrderdetailsID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderID"] = new SelectList(_context.Order, "OrderID", "OrderID", orderdetails.OrderID);
            ViewData["ProductID"] = new SelectList(_context.Product, "ProductID", "ProductID", orderdetails.ProductID);
            return View(orderdetails);
        }

        // GET: Orderdetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Orderdetails == null)
            {
                return NotFound();
            }

            var orderdetails = await _context.Orderdetails
                .Include(o => o.Order)
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.OrderdetailsID == id);
            if (orderdetails == null)
            {
                return NotFound();
            }

            return View(orderdetails);
        }

        // POST: Orderdetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Orderdetails == null)
            {
                return Problem("Entity set 'kellyDbContext.Orderdetails'  is null.");
            }
            var orderdetails = await _context.Orderdetails.FindAsync(id);
            if (orderdetails != null)
            {
                _context.Orderdetails.Remove(orderdetails);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderdetailsExists(int id)
        {
          return (_context.Orderdetails?.Any(e => e.OrderdetailsID == id)).GetValueOrDefault();
        }
    }
}
