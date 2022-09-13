using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.Data.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FlowerShop.Data.Share.DbContext
{
    public class FlowerShopDbContext:IdentityDbContext<User>
    {
        public FlowerShopDbContext(DbContextOptions options):base(options){}
    }
}
