using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProductMVC.Controllers.api
{
    //public class ProductController : ApiController
    //{
    //    //public IEnumerable<> GetAllProducts

    //    [HttpGet]
    //    public IHttpActionResult GetProduct(int id)
    //    {
    //        var product = repository.Product.Where(p => p.Articlenumber == id)
    //            .Select(p => new ProductInfo { ActionNameAttribute = p.Name, Price = p.Price })
    //            .DefaultIfEmpty()
    //            .First();

    //        if(product == null)
    //        {
    //            return NotFound();
    //        }
    //        return Ok(product);
    //    }
    //    [HttpGet]
    //    public IEnumerable<ProductsController> GetAllProducts()
    //    {
    //        var result = repository.Products
    //            .select(p => new ProductInfo
    //            {
    //                Name = p.Name,
    //                Price = p.Price
    //            });
    //    }
    //}
}
