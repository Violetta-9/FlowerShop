using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.Application.Command.Order.MakeOrder;
using FlowerShop.Application.Contracts.Outgoing;
using FlowerShop.Data.Domain.Models;
using FlowerShop.Data.Share.DbContext;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FlowerShop.Application.CommandHandler.Order.MakeOrder
{
    public class MakeOrderCommandHandler:IRequestHandler<MakeOrderCommand,long>
    {
        private readonly FlowerShopDbContext _db;
        private readonly UserManager<ShopUser> _userManager;
        public MakeOrderCommandHandler(FlowerShopDbContext db, UserManager<ShopUser> userM)
        {
            _db = db;
            _userManager = userM;
        }
        public async Task<long> Handle(MakeOrderCommand request, CancellationToken cancellationToken)
        {
            var currentUser = await _userManager.FindByNameAsync(request.UserName);
            var productFromCard = _db.ProductsItem.Where(x => x.UserId == currentUser.Id && x.OrderId == null);
            var order = new Data.Domain.Models.Order()
            {
                UserId = currentUser.Id,
                Quentity = productFromCard
                    .Sum(x => x.Quentity),
                TotalPrice = productFromCard
                    .Sum(x => x.Quentity * x.Product.Price),
                Address = request.Address,
                TimeOfOrder = DateTime.Now,
                IsCompleted = false

            };
             await _db.ProductOrders.AddAsync(order, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);
           await productFromCard.ForEachAsync(x => x.OrderId = order.Id,cancellationToken);
           await _db.SaveChangesAsync(cancellationToken);
            return order.Id;

        }

        
    }
}
