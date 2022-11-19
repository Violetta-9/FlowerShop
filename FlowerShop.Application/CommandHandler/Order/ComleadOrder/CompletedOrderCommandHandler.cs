using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.Application.Command.Order.CompleadOrder;
using FlowerShop.Application.Contracts.Outgoing;
using FlowerShop.Data.Share.DbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FlowerShop.Application.CommandHandler.Order.ComleadOrder
{
    internal class CompletedOrderCommandHandler:IRequestHandler<CompletedOrderCommand,Response>
    {
        private readonly FlowerShopDbContext _db;
        public CompletedOrderCommandHandler(FlowerShopDbContext db)
        {
            _db = db;
        }

        public async Task<Response> Handle(CompletedOrderCommand request, CancellationToken cancellationToken)
        {
          var order= await _db.ProductOrders.Where(x => x.Id == request.OrderId).FirstOrDefaultAsync(cancellationToken);
          order.IsCompleted = !order.IsCompleted;
          await _db.SaveChangesAsync(cancellationToken);
          return Response.Success;
        }
    }
}
