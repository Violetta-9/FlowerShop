using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.Application.Command.User;
using FluentValidation;

namespace FlowerShop.Application.Validators.Commands.User.Registration
{
    public class RegistrationValidator:AbstractValidator<RegisterCommand>
    {
        public RegistrationValidator()
        {
            CreateRules();
        }

        private void CreateRules()
        {
            RuleFor(x => x.NewUser.Email)
                .Cascade(CascadeMode.Stop);
            //todo:

        }

       
    }
}
