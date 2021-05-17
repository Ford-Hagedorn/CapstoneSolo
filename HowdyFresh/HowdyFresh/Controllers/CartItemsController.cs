using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HowdyFresh.Data;
using HowdyFresh.Models;

namespace HowdyFresh.Controllers
{
    public class CartItemsController : Controller
    {
        private ApplicationDbContext objCartItemIdentities;
        private readonly ApplicationDbContext _context;

        public CartItemsController()
        {
            objCartItemIdentities = new ApplicationDbContext();
        }
        // GET: CartItems
        public ActionResult Index()
        {
            CartItem objCartItem = new CartItem();
            objCartItem.CategorySelectListItem = (from objCat in objCartItemIdentities.Categories
                select new SelectListItem()
                    {
                        Text = objCat.CategoryName,
                        Value = objCat.CategoryId.ToString(),
                        Selected = true
                     });
            return View(objCartItem);
        }
        [HttpPost]
        public JsonResult Index(CartItem objCartItem)
        {
            CartItem objItem = new CartItem();
            objItem.CategoryId = objCartItem.CategoryId;
            objItem.Description = objCartItem.Description;
            objItem.ItemCode = objCartItem.ItemCode;
            objItem.ItemName = objCartItem.ItemName;
            objItem.ItemId = Guid.NewGuid();
            objItem.ItemPrice = objCartItem.ItemPrice;
            objCartItemIdentities.CartItems.Add(objItem);
            objCartItemIdentities.SaveChanges();
            return Json(data: new { Success = true, Message = "Added successfully!" });
        }

        // GET: CartItems/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartItem = await _context.CartItems
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (cartItem == null)
            {
                return NotFound();
            }

            return View(cartItem);
        }

        // GET: CartItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CartItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemId,CategoryId,ItemCode,ItemName,Description,ItemPrice")] CartItem cartItem)
        {
            if (ModelState.IsValid)
            {
                cartItem.ItemId = Guid.NewGuid();
                _context.Add(cartItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cartItem);
        }

        // GET: CartItems/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartItem = await _context.CartItems.FindAsync(id);
            if (cartItem == null)
            {
                return NotFound();
            }
            return View(cartItem);
        }

        // POST: CartItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ItemId,CategoryId,ItemCode,ItemName,Description,ItemPrice")] CartItem cartItem)
        {
            if (id != cartItem.ItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cartItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartItemExists(cartItem.ItemId))
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
            return View(cartItem);
        }

        // GET: CartItems/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartItem = await _context.CartItems
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (cartItem == null)
            {
                return NotFound();
            }

            return View(cartItem);
        }

        // POST: CartItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var cartItem = await _context.CartItems.FindAsync(id);
            _context.CartItems.Remove(cartItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CartItemExists(Guid id)
        {
            return _context.CartItems.Any(e => e.ItemId == id);
        }
    }
}
