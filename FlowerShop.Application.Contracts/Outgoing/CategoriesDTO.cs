﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.Application.Contracts.Outgoing
{
    public class CategoriesDTO
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
      
    }
}
