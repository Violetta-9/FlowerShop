using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.Application.Command.ProductCard.ChangeQuentity;
using FlowerShop.Data.Domain.Models;
using FlowerShop.Data.Share.DbContext;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FlowerShop.Application.CommandHandler.ProductCard.ChangeQuentity
{
    internal class ChangeQuentityCommandHandler:IRequestHandler<ChangeQuentityCommand,int>
    {
        private readonly FlowerShopDbContext _db;
        private readonly UserManager<ShopUser> _userManager;
        public ChangeQuentityCommandHandler(FlowerShopDbContext db, UserManager<ShopUser> userM)
        {
            _db = db;
            _userManager = userM;
        }
        public async Task<int> Handle(ChangeQuentityCommand request, CancellationToken cancellationToken)
        {
            var currentUser = await _userManager.FindByNameAsync(request.UserName);
            var product = await _db.ProductsItem.Where(x =>
                    x.UserId == currentUser.Id && x.OrderId == null && x.ProductId == request.ProductId)
                .FirstOrDefaultAsync(cancellationToken);
            product.Quentity += request.Number;
           await _db.SaveChangesAsync(cancellationToken);
           return product.Quentity;
        }
    }
}
