using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using kelly.Areas.Identity.Data;
using kelly.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace kelly.Controllers
{
    [Authorize]
    public class OrderDetailsController : Controller
    {
        private readonly kellyDbContext _context;

        public OrderDetailsController(kellyDbContext context)
        {
            _context = context;
        }

        // GET: OrderDetails
        public async Task<IActionResult> Index()
        {
            var kellyDbContext = _context.OrderDetails.Include(o => o.Orders).Include(o => o.Product);
            return View(await kellyDbContext.ToListAsync());
        }

        // GET: OrderDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OrderDetails == null)
            {
                return NotFound();
            }

            var orderDetails = await _context.OrderDetails
                .Include(o => o.Orders)
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.OrderDetailsID == id);
            if (orderDetails == null)
            {
                return NotFound();
            }

            return View(orderDetails);
        }

        // GET: OrderDetails/Create
        public IActionResult Create()
        {
            ViewData["OrdersID"] = new SelectList(_context.Orders, "OrdersID", "FirstName");
            ViewData["ProductID"] = new SelectList(_context.Product, "ProductID", "ProductID");
            return View();
        }

        // POST: OrderDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderDetailsID,OrdersID,ProductID,ProductName,Qty")] OrderDetails orderDetails)
        {
            if (orderDetails.Qty <= 1)
            {
                ModelState.AddModelError("", "Price can not be less than 1");
                return View(orderDetails);
            }
            if (!ModelState.IsValid)
            {
                _context.Add(orderDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrdersID"] = new SelectList(_context.Orders, "OrdersID", "FirstName", orderDetails.OrdersID);
            ViewData["ProductID"] = new SelectList(_context.Product, "ProductID", "ProductID", orderDetails.ProductID);
            return View(orderDetails);
        }

        // GET: OrderDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OrderDetails == null)
            {
                return NotFound();
            }

            var orderDetails = await _context.OrderDetails.FindAsync(id);
            if (orderDetails == null)
            {
                return NotFound();
            }
            ViewData["OrdersID"] = new SelectList(_context.Orders, "OrdersID", "FirstName", orderDetails.OrdersID);
            ViewData["ProductID"] = new SelectList(_context.Product, "ProductID", "ProductID", orderDetails.ProductID);
            return View(orderDetails);
        }

        // POST: OrderDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderDetailsID,OrdersID,ProductID,ProductName,Qty")] OrderDetails orderDetails)
        {
            if (id != orderDetails.OrderDetailsID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderDetailsExists(orderDetails.OrderDetailsID))
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
            ViewData["OrdersID"] = new SelectList(_context.Orders, "OrdersID", "FirstName", orderDetails.OrdersID);
            ViewData["ProductID"] = new SelectList(_context.Product, "ProductID", "ProductID", orderDetails.ProductID);
            return View(orderDetails);
        }

        // GET: OrderDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OrderDetails == null)
            {
                return NotFound();
            }

            var orderDetails = await _context.OrderDetails
                .Include(o => o.Orders)
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.OrderDetailsID == id);
            if (orderDetails == null)
            {
                return NotFound();
            }

            return View(orderDetails);
        }

        // POST: OrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OrderDetails == null)
            {
                return Problem("Entity set 'kellyDbContext.OrderDetails'  is null.");
            }
            var orderDetails = await _context.OrderDetails.FindAsync(id);
            if (orderDetails != null)
            {
                _context.OrderDetails.Remove(orderDetails);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderDetailsExists(int id)
        {
          return (_context.OrderDetails?.Any(e => e.OrderDetailsID == id)).GetValueOrDefault();
        }
    }
}
