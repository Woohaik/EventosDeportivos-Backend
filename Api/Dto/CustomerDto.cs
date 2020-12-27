using Domain.Models.ICustomerContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Dto
{
    public class CustomerDto
    {

        public readonly int id;
        public readonly string name;
        public readonly string lastname;
        public readonly string email;
        public readonly string dni;

        public CustomerDto(ICustomer customer)
        {
            this.id = customer.id;
            this.name = customer.name;
            this.lastname = customer.lastname;
            this.email = customer.email;
            this.dni = customer.dni;
        }
    }
}