using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.models
{
    public class AuthenticationModel
    {
        public string token { get; set; }
        public CustomerModel customerModel { get; set; }

    }
}
