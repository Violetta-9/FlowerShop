using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.Data.Domain.Models.Abstractions;

namespace FlowerShop.Data.Domain.Models
{
    public class Product: PrimaryKey
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public bool IsHidden { get; set; }=false;
        public long? ProductCategoryId { get; set; }
        public virtual ProductCategory ProductCategories { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
        public virtual ICollection<ProductItem> ProductList { get; set; }
    }
}
