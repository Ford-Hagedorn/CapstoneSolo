using HowdyFresh.Data;
using HowdyFresh.Models;
using Microsoft.AspNetCore.Http;
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
        private List<Cart> listOfCart;
        
        public Shopping()
        {
            objCartEntities = new ApplicationDbContext();
            listOfCart = new List<Cart>(); 
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
        public JsonResult Index(string ItemId)
        {
               
            Cart objCart = new Cart();
            CartItem objItem = objCartEntities.CartItems.Single(model => model.ItemId.ToString() == ItemId);
            if(listOfCart.Any(model => model.ItemId == ItemId))
            {
                objCart = listOfCart.Single(model => model.ItemId == ItemId);
                objCart.Quantity = objCart.Quantity + 1;
                objCart.Total = objCart.Quantity * objCart.UnitPrice;
            }
            else
            {
                objCart.ItemId = ItemId;
                objCart.ItemName = objItem.ItemName;
                objCart.Quantity = 1;
                objCart.Total = objItem.ItemPrice;
                objCart.UnitPrice = objItem.ItemPrice;
                listOfCart.Add(objCart);
            }
            Session["CartCounter"] = listOfCart.Count;
            Session.SetObject["CartItem"] = listOfCart;
            
            return Json(new { Success = true, Counter = listOfCart.Count });
        }
    }
}
