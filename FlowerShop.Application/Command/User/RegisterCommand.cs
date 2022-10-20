using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.Application.Contracts.Incoming.User;
using FlowerShop.Application.Contracts.Outgoing;
using MediatR;

namespace FlowerShop.Application.Command.User
{
    public class RegisterCommand:IRequest<Response>
    {
        public AddUserDTO NewUser { get; set; }

        public RegisterCommand(AddUserDTO newUser)
        {
            NewUser = newUser;
        }
    }
}
