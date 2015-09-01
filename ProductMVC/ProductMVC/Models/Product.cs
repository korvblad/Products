using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProductMVC.Models
{
    public class Product
    {
            public string Name {get;set;}
            public int ID {get;set;}
            public float Price { get; set; }
            [DisplayName ("Article Number")]
            public long ArticleNumber { get; set; }
            //public string ImageURL { get; set; }
            [BindableAttribute(true)]
            public virtual string ImageUrl { get; set; }
    }
        public class ProductDbContext : DbContext
        {
            public DbSet<Product> Products {get;set;}
        }
    }
