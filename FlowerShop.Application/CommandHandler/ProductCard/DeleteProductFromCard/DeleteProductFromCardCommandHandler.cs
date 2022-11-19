using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.Application.Command.ProductCard.DeleteProductFromCard;
using FlowerShop.Application.Contracts.Outgoing;
using FlowerShop.Data.Domain.Models;
using FlowerShop.Data.Share.DbContext;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FlowerShop.Application.CommandHandler.ProductCard.DeleteProductFromCard
{
    public  class DeleteProductFromCardCommandHandler:IRequestHandler<DeleteProductFromCardCommand,Response>
    {
        private readonly FlowerShopDbContext _db;
        private readonly UserManager<ShopUser> _userManager;
        public DeleteProductFromCardCommandHandler(FlowerShopDbContext db, UserManager<ShopUser> userM)
        {
            _db = db;
            _userManager = userM;
        }
        public async Task<Response> Handle(DeleteProductFromCardCommand request, CancellationToken cancellationToken)
        {
            var currentUser = await _userManager.FindByNameAsync(request.UserName);
            var product = await _db.ProductsItem.Where(x =>
                x.UserId == currentUser.Id && x.OrderId == null && x.ProductId == request.ProductId).FirstOrDefaultAsync(cancellationToken);
            _db.ProductsItem.Remove(product);
            await _db.SaveChangesAsync(cancellationToken);
            return Response.Success;
        }
    }
}
