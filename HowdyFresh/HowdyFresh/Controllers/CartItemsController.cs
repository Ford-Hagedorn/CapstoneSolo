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
                objCartItemIdentities.Add(cartItem);
                await objCartItemIdentities.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cartItem);
        }
    }
}
