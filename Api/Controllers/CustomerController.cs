using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Collections.Generic;
using Domain.Models.Customer;
using Domain.Services.Customer.crud;
using Domain.Services.Customer;

namespace Api.Controllers
{
    public class CustomerController : ApiController
    {
        private ICustomerCrud customerCrudServices = CustomerService.Instance;

        [HttpPost]
        public HttpResponseMessage RegisterCustomer(CustomerModel customer)
        {

            customerCrudServices.RegisterCustomer(customer);
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Created);
            return response;
        }

        public HttpResponseMessage GetCustomers()
        {
            CustomerModel model = new CustomerModel()
            {

                dni = "d",
                email = "themail",
                lastname = "thelast",
                name = "Wiii"

            };

            List<CustomerModel> theList = new List<CustomerModel>();
            theList.Add(model);


            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, theList);
            return response;
        }
    }
}
