using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.Application.Queries.Product;
using FlowerShop.Application.Resources;
using FlowerShop.Data.Share.DbContext;
using FluentValidation;

namespace FlowerShop.Application.Validators.Queries.Product.GetProductById
{
    public class GetProductByIdValidator:AbstractValidator<GetProductByIdQuery>
    {
        private readonly FlowerShopDbContext _db;
        public GetProductByIdValidator(FlowerShopDbContext db)
        {
            _db = db;
            CreateRules();
        }

        private void CreateRules()
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .Must(IsExsistProduct)
                .WithMessage(Message.DoNotExsistProductCategory);
        }

        private bool IsExsistProduct(long arg)
        {
            return _db.Products.Any(x => x.Id == arg);
        }
    }
}
