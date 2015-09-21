using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProductMVC.Models;

namespace ProductMVC.Views
{
    public class ProductssController : Controller
    {
        private ProductDbContext db = new ProductDbContext();

        // GET: Productss
        public ActionResult Index(string SearchGenre, string SearchString)
        {
            var GenreLst = new List<string>();
            var GenreQry = from d in db.Products
                           orderby d.Genre
                           select d.Genre;

            GenreLst.AddRange(GenreQry.Distinct());
            ViewBag.SearchGenre = new SelectList(GenreLst);

            var products = from p in db.Products
                           select p;

            if (!String.IsNullOrEmpty(SearchString))
            {
                products = products.Where(s => s.Name.Contains(SearchString));
            }
            
            if(!string.IsNullOrEmpty(SearchGenre))
            {
                products = products.Where(x => x.Genre == SearchGenre);
            }
            return View(products);
        }

        // GET: Productss/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Productss/Create
        [Authorize(Users = "admin@admin.se")]
        public ActionResult Create()

        {
            return View();
        }

        // POST: Productss/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Users = "admin@admin.se")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Price,ArticleNumber,ImageUrl,Genre,CategoryId")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Productss/Edit/5
        [Authorize(Users = "admin@admin.se")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Productss/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Users = "admin@admin.se")]
        public ActionResult Edit([Bind(Include = "ID,Name,Price,ArticleNumber,ImageUrl,Genre,CategoryId")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Productss/Delete/5
        [Authorize(Users = "admin@admin.se")]
        public ActionResult Delete(int? id)

        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        public Cart NewSession() // skapar en ref objekt av ett Session Objekt till att lagra gissningar
        {
            var CartItems = Session["savedList"] as Cart;

            if (CartItems == null)
            {
                CartItems = new Cart();
                Session["savedList"] = CartItems;
            }
            return CartItems;
        }

        // POST: Productss/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Users = "admin@admin.se")]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
