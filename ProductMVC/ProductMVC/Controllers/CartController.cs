
using ProductMVC.Abstract;
using ProductMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ProductMVC.Controllers
{
    public class CartController : Controller
    {
        private ProductDbContext db = new ProductDbContext();

       
        //Index action method
        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
                {
                    Cart = GetCart(),
                    ReturnUrl = returnUrl
                });
        }

        public RedirectToRouteResult AddToCart(int id, string returnUrl)
        {
            Product product = db.Products
                .FirstOrDefault(p => p.ID == id);

            if (product != null)
            {
                GetCart().AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToRouteResult RemoveFromCart(int id, string returnUrl)
        {
            Product product = db.Products
                .FirstOrDefault(p => p.ID == id);
            if (product != null)
            {
                GetCart().RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        private Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(GetCart());
        }
   } 
}
