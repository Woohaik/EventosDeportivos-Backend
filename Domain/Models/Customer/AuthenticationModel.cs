﻿using Domain.Models.ICustomerContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Customer
{
    public class AuthenticationModel : IAuthentication
    {
        public string token { get; set; }
        public ICustomer customer { get; set; }
    }
}
