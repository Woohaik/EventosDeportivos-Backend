
using Data.DBMODELS;
using Data.Repositories;
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
    public class CustomerCrud : ICrud<ICustomer>
    {

        protected ICustomerRepository customerRepository = CustomerRepository.Instance;


        public async Task Add(ICustomer model)
        {

            customers dbCustomer = new customers()
            {
                customerdni = model.dni,
                customerlastname = model.lastname,
                customername = model.name,
                customeremail = model.email,
                customerpassword = this.hashPassword(model.password)
            };

            await this.customerRepository.Add(dbCustomer);
        }

        public async Task DeleteById(int id) =>
            await this.customerRepository.DeleteById(id);


        public async Task<IEnumerable<ICustomer>> GetAll()
        {
            IEnumerable<customers> customers = await this.customerRepository.GetAll();
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
            };

            await this.customerRepository.UpdateById(id, dbCustomer);
        }

        private string hashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt(12));
        }
    }
}
