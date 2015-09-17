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
        private ProductDbContext repository;

        public CartController(ProductDbContext repo)
        {
            repository = repo;
        }
        public RedirectToRouteResult AddToCart(int id, string returnUrl)
        {
            Product product = repository.Products
                .FirstOrDefault(p => p.ID == id);

            if (product != null)
            {
                GetCart().AddItem(product, 1);
            }
            return RedirectToAction("Index", new object { returnUrl });
        }
        public RedirectToRouteResult RemoveFromCart(int id, string returnUrl)
        {
            Product product = repository.Products
                .FirstOrDefault(p => p.ID == id);
            if (product != null)
            {
                GetCart().RemoveLine(product);
            }
            return RedirectToAction("Index", new object { returnUrl });
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

   } 
}
