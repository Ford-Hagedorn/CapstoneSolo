using HowdyFresh.Data;
using HowdyFresh.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HowdyFresh.Controllers
{
    public class Shopping : Controller
    {
        private ApplicationDbContext objCartEntities;
        public Shopping()
        {
            objCartEntities = new ApplicationDbContext();
        }
        public IActionResult Index()
        {
            IEnumerable<ShoppingCart> listOfShoppingCart = (from objItem in objCartEntities.CartItems
                join objCats in objCartEntities.Categories on objItem.CategoryId equals objCats.CategoryId
                select new ShoppingCart()
                    {
                        ItemName = objItem.ItemName,
                        Description = objItem.Description,
                        ItemPrice = objItem.ItemPrice,
                        ItemId = objItem.ItemId,
                        Category = objCats.CategoryName,
                        ItemCode = objItem.ItemCode
                    }
                ).ToList();
            return View(listOfShoppingCart);
        }
    }
}
