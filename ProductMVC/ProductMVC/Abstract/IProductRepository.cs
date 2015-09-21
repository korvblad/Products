using ProductMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMVC.Abstract
{
    public interface IProductRepository
    {
        IEnumerable<Product> Product { get; }
    }
}
