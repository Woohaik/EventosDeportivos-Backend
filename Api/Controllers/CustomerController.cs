using Domain.Models.Customer;
using Domain.Models.ICustomerContracts;
using Domain.Services;
using Domain.Services.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Api.Controllers
{
    public class CustomerController : ApiController
    {
        private ICrud<ICustomer> customerAuthServices = CustomerService.Instance;

        [HttpPost]
        public async Task<HttpResponseMessage>  RegisterCustomer([FromBody]CustomerModel customer)
        {
            await this.customerAuthServices.Add(customer);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
