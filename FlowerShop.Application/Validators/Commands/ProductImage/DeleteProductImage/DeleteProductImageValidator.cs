using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.Application.Command.ProductImage;
using FlowerShop.Application.Resources;
using FlowerShop.Data.Share.DbContext;
using FluentValidation;

namespace FlowerShop.Application.Validators.Commands.ProductImage.DeleteProductImage
{
    public class DeleteProductImageValidator:AbstractValidator<DeleteProductImageCommand>
    {
        private readonly FlowerShopDbContext _db;
        public DeleteProductImageValidator(FlowerShopDbContext db)
        {
            _db = db;
            CreateRules();
        }

        private void CreateRules()
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .Must(IsExsistProductImage)
                .WithMessage(Message.DoNotExsistProductImage);
        }

        private bool IsExsistProductImage(long arg)
        {
            return _db.ProductImages.Any(x => x.Id == arg);
        }
    }
}
