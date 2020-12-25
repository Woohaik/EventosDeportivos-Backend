using Api.Validators;
using Domain.Models.Customer;
using Domain.Models.ICustomerContracts;
using Domain.Services;
using Domain.Services.Customer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace Api.Controllers
{
    public class CustomerController : ApiController
    {
        private ICrud<ICustomer> customerCrudServices = CustomerService.Instance;
        private AnotationValidator<CustomerModel> validator = new AnotationValidator<CustomerModel>();

        public async Task<HttpResponseMessage> GetCustomers()
        {
            IEnumerable<ICustomer> allCustomers = null;
            Thread hilo = new Thread(() => allCustomers = this.customerCrudServices.GetAll());

            await Task.Run(() =>
            {
                hilo.Start();
                hilo.Join();
            });
            return Request.CreateResponse(HttpStatusCode.OK, allCustomers);
        }

        public async Task<HttpResponseMessage> GetCustomer(int id)
        {
            ICustomer customer = await this.customerCrudServices.GetById(id);
            return Request.CreateResponse(HttpStatusCode.OK, customer);
        }

        [HttpPost]
        public async Task<HttpResponseMessage> RegisterCustomer([FromBody] CustomerModel customer)
        {
            try
            {
                validator.validate(customer);
                await this.customerCrudServices.Add(customer);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        [HttpPut]
        public async Task<HttpResponseMessage> UpdateCustomer(int id, [FromBody] CustomerModel customer)
        {
            await this.customerCrudServices.UpdateById(id, customer);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> DeletCustomer(int id)
        {
            await this.customerCrudServices.DeleteById(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
