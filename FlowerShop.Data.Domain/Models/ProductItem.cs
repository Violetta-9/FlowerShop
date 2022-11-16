using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.Data.Domain.Models.Abstractions;

namespace FlowerShop.Data.Domain.Models
{
    public class ProductItem:PrimaryKey
    {
        public string UserId { get; set; }
        public long ProductId { get; set; }
        public long? OrderId { get; set; }
        public int Quentity { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
        public virtual ShopUser User { get; set; }
    }
}
