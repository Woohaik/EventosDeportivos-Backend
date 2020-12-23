
using Data;
using Domain.Models.ICustomerContracts;
using Domain.Services.Customer.auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Customer.crud
{
    public class CustomerCrud : CustomerAuth, ICrud<ICustomer>
    {
        public async Task Add(ICustomer model)
        {

            customers entity = new customers()
            {
                customerdni = model.dni,
                customerlastname = model.lastname,
                customername = model.name,
                customeremail = model.email,
                customerpassword = "warioo"


            };


        await this.customerRepository.Add(entity);

        }

        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ICustomer> GetAll()
        {
            throw new NotImplementedException();
        }

        public ICustomer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateById(int id, ICustomer model)
        {
            throw new NotImplementedException();
        }
    }
}
