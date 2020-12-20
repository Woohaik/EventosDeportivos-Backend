using Domain.models;
using Domain.Services.Customer.auth;
using Domain.Services.Customer.crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Customer
{
    public interface ICustomerService : ICustomerCrud, IAuth
    { }
}
