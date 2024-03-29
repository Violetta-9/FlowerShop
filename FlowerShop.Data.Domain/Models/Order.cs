﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.Data.Domain.Models.Abstractions;

namespace FlowerShop.Data.Domain.Models
{
    public  class Order: PrimaryKey
    {
        public string UserId { get; set; }
        public int Quentity { get; set; }
        public double TotalPrice { get; set; }
        public string Address { get; set; }
        public DateTime TimeOfOrder { get; set; }
        public bool IsCompleted { get; set; } = false;
        public virtual ShopUser User { get; set; }
        public virtual ICollection<ProductItem> ProductsList { get; set; }
    }
}
