using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.Application.Contracts.Incoming
{
    public class LoginDTO
    {
        public string UserLoginOrEmail { get; set; }
        public string Password { get; set; }
    }
}
