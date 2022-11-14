using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.Application.Contracts.Outgoing;
using FlowerShop.Application.Queries.FlowerProductCategory;
using FlowerShop.Data.Domain.Models;
using FlowerShop.Data.Share.DbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FlowerShop.Application.QueriesHandler.FlowerProductCategory
{
    public class GetAllProductCategoriesQueriesHandler : IRequestHandler<GetAllProductCategoriesQueries, CategoriesDTO[]>
    {
        private readonly FlowerShopDbContext _db;
        public GetAllProductCategoriesQueriesHandler(FlowerShopDbContext db)
        {
            _db = db;
        }

        public async Task<CategoriesDTO[]> Handle(GetAllProductCategoriesQueries request, CancellationToken cancellationToken)
        {
            var listOfCategories = await _db.ProductCategories.ToArrayAsync(cancellationToken);

            return listOfCategories.Select(x => new CategoriesDTO() { Description = x.Description, Title = x.Title, Id = x.Id}).ToArray();
        }
    }
}
