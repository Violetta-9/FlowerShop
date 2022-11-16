using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.Application.Command.ProductCard.AddProductInCard;
using FlowerShop.Application.Contracts.Outgoing;
using FlowerShop.Data.Domain.Models;
using FlowerShop.Data.Share.DbContext;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FlowerShop.Application.CommandHandler.ProductCard.AddProductInCard
{
    public class AddProductIntoCardCommandHandler : IRequestHandler<AddProductInCardCommand, Response>
    {
        private readonly FlowerShopDbContext _db;
        private readonly UserManager<ShopUser> _userManager;
        public AddProductIntoCardCommandHandler(FlowerShopDbContext db,UserManager<ShopUser> userM)
        {
            _db = db;
            _userManager = userM;
        }

        public async Task<Response> Handle(AddProductInCardCommand request, CancellationToken cancellationToken)
        {
            var currentUser = await _userManager.FindByNameAsync(request.newProduct.UserName);
            var productInCard = new ProductItem()
            {
                ProductId = request.newProduct.ProductId,
                Quentity = request.newProduct.Quentity,
                UserId = currentUser.Id,
            };
           await _db.ProductsItem.AddAsync(productInCard,cancellationToken);
          await _db.SaveChangesAsync(cancellationToken);
            return Response.Success;
        }
    }
}
