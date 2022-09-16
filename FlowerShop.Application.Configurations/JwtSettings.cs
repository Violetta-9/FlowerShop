using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.Application.Configurations
{
    public class JwtSettings
    {
        public string JwtSecretKey { get; set; }

        public JwtSettings() { }

        public JwtSettings(string jwtSecretKey)
        {
            JwtSecretKey = jwtSecretKey;
        }
    }
}
