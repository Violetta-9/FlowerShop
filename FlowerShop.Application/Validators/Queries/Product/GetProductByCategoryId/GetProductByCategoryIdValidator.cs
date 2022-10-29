using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.Application.Queries.Product;
using FlowerShop.Application.Resources;
using FlowerShop.Data.Share.DbContext;
using FluentValidation;

namespace FlowerShop.Application.Validators.Queries.Product.GetProductByCategoryId
{
    public class GetProductByCategoryIdValidator:AbstractValidator<GetProductByCategoryIdQuery>
    {
        private readonly FlowerShopDbContext _db;
        public GetProductByCategoryIdValidator(FlowerShopDbContext db)
        {
            _db = db;
            CreateRules();
        }

        private void CreateRules()
        {
            RuleFor(x => x.CategoryId)
                .Cascade(CascadeMode.Stop)
                .Must(IsExsistProductCategory)
                .WithMessage(Message.DoNotExsistProductCategory);
        }

        private bool IsExsistProductCategory(long arg)
        {
            return _db.ProductCategories.Any(x => x.Id == arg);
        }
    }
}
