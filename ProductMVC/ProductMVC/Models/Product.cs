using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProductMVC.Models
{
    public class Product
    {
            [DisplayName ("Namn")]
            public string Name {get;set;}
            public int ID {get;set;}
            [DisplayName("Pris")]
            public float Price { get; set; }
            [DisplayName ("Artikelnummer")]
            public long ArticleNumber { get; set; }
            [BindableAttribute(true)]
            [DisplayName ("Bild")]
            public string ImageUrl { get; set; }
            public string CategoryId { get; set; }
    }
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string Name{get; set;}
        public ICollection<Product> Products { get; set; }   
    }
        public class ProductDbContext : DbContext
        {
            public DbSet<Product> Products {get;set;}
        }
    }
