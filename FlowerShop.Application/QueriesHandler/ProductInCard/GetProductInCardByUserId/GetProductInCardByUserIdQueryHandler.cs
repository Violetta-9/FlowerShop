using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.Application.Contracts.Outgoing;
using FlowerShop.Application.Queries.ProductInCard.GetAllProductInCardByUserId;
using FlowerShop.Data.Domain.Models;
using FlowerShop.Data.Share.DbContext;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FlowerShop.Application.QueriesHandler.ProductInCard.GetProductInCardByUserId
{
    public class GetProductInCardByUserIdQueryHandler : IRequestHandler<GetProductInCardByUserIdQuery, ProductDTO[]>
    {
        private readonly FlowerShopDbContext _db;
        private readonly UserManager<ShopUser> _userManager;
        public GetProductInCardByUserIdQueryHandler(FlowerShopDbContext db, UserManager<ShopUser> userM)
        {
            _db = db;
            _userManager = userM;
        }

        public async Task<ProductDTO[]> Handle(GetProductInCardByUserIdQuery request, CancellationToken cancellationToken)
        {
            var currentUser = await _userManager.FindByNameAsync(request.UserName);
            return await _db.ProductsItem.Where(x => x.UserId == currentUser.Id && x.OrderId == null).Select(x=>new ProductDTO()
            {
                Title = x.Product.Title,
                Description = x.Product.Description,
                Id=x.ProductId,
                Price = x.Product.Price,
                Quentity = x.Quentity,
                ProductCategoryId = x.Product.ProductCategoryId
            }).ToArrayAsync(cancellationToken);

        }
    }
}
