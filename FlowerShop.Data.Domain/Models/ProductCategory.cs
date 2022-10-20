using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.Data.Domain.Models.Abstractions;

namespace FlowerShop.Data.Domain.Models
{
    public class ProductCategory:PrimaryKey
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
