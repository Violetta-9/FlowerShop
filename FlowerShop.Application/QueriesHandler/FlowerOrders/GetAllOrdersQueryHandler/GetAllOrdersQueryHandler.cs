using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.Application.Contracts.Outgoing;
using FlowerShop.Application.Queries.FlowerOrders.GetAllOrdersQuery;
using FlowerShop.Data.Share.DbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FlowerShop.Application.QueriesHandler.FlowerOrders.GetAllOrdersQueryHandler
{
    internal class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, IEnumerable<OrdersDTO>>
    {
        private readonly FlowerShopDbContext _db;
        public GetAllOrdersQueryHandler(FlowerShopDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<OrdersDTO>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
         var orders= await _db.ProductOrders.Where(x => x.IsCompleted==request.IsCompleated).ToArrayAsync();
         return orders.Select(x=>new OrdersDTO()
         {
             OrderId = x.Id,
             Phone = x.User.PhoneNumber,
             UserAdress = x.Address,
             TotalPrice = x.TotalPrice,
             TimeOfOrder = x.TimeOfOrder,
             IsCompleted = x.IsCompleted,
             FlowerTitle = x.ProductsList.Where(u=>u.UserId==x.UserId && u.OrderId==x.Id).Select(u=>u.Product.Title).ToArray(),

         });


        }
    }
}
