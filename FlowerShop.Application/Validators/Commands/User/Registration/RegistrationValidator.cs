using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.Application.Command.User;
using FlowerShop.Application.Resources;
using FlowerShop.Data.Share.DbContext;
using FluentValidation;

namespace FlowerShop.Application.Validators.Commands.User.Registration
{
    public class RegistrationValidator:AbstractValidator<RegisterCommand>
    {
        private readonly FlowerShopDbContext _db;
        public RegistrationValidator(FlowerShopDbContext db)
        {
            _db =db;
            CreateRules();
        }

        private void CreateRules()
        {
            RuleFor(x => x.NewUser.Login)
                .Cascade(CascadeMode.Stop)
                .Must(UniqLogin)
                .WithMessage(Message.LoginAlreadyExists);

        }

        private bool UniqLogin(string arg)
        {
           return _db.UserLogins.Any(x => x.LoginProvider==arg);
        }

        
    }
}
