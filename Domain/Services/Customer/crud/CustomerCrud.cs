
using Data;
using Domain.Models.Customer;
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

            customers dbCustomer = new customers()
            {
                customerdni = model.dni,
                customerlastname = model.lastname,
                customername = model.name,
                customeremail = model.email,
                customerpassword = "warioo"
            };


            await this.customerRepository.Add(dbCustomer);

        }

        public async Task DeleteById(int id)
        {
            await this.customerRepository.DeleteById(id);
        }

        public IEnumerable<ICustomer> GetAll()
        {
            IEnumerable<customers> customers = this.customerRepository.GetAll();
            List<ICustomer> domainCustomers = new List<ICustomer>();

            foreach (customers dbCustomer in customers)
            {
                domainCustomers.Add(new CustomerModel()
                {
                    
                    dni = dbCustomer.customerdni,
                    name = dbCustomer.customername,
                    lastname = dbCustomer.customerlastname,
                    email = dbCustomer.customeremail,
                    id = dbCustomer.customerid
                });
            }

            return domainCustomers;
        }

        public async Task<ICustomer> GetById(int id)
        {
            customers dbCustomer = await this.customerRepository.GetById(id);
            ICustomer domainCustomer = new CustomerModel()
            {
                dni = dbCustomer.customerdni,
                name = dbCustomer.customername,
                lastname = dbCustomer.customerlastname,
                email = dbCustomer.customeremail,
                id = dbCustomer.customerid
            };

            return domainCustomer;
        }

        public async Task UpdateById(int id, ICustomer model)
        {
            customers dbCustomer = new customers()
            {
                customerdni = model.dni,
                customerlastname = model.lastname,
                customername = model.name,
                customeremail = model.email,
                customerpassword = "warioo"
            };

            await this.customerRepository.UpdateById(id, dbCustomer);
        }
    }
}
