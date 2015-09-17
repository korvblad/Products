using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
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
            public decimal Price { get; set; }
            [DisplayName ("Artikelnummer")]
            public long ArticleNumber { get; set; }
            [BindableAttribute(true)]
            [DisplayName ("Bild")]
            public string ImageUrl { get; set; }
            [DisplayName("Genre")]
            public string Genre { get; set; }
            public string CategoryId { get; set; }
    }
    public class Category
    {
        [Key]
        public virtual int CategoryId { get; set; }
        public string Name{get; set;}
        public virtual ICollection<Product> Products { get; set; }   
    }
        public class ProductDbContext : DbContext
        {
            public DbSet<Product> Products {get;set;}
            public DbSet<Category> Category { get; set; }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

                modelBuilder.Entity<Product>();
                modelBuilder.Entity<Category>();
            }

            public System.Data.Entity.DbSet<ProductMVC.Models.Admin> Admins { get; set; }
        }
    }
