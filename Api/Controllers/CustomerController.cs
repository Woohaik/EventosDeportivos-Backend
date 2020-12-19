using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Collections.Generic;
using Domain.models;

namespace Api.Controllers
{
    public class CustomerController : ApiController
    {

        [HttpPost]
        public HttpResponseMessage RegisterCustomer(CustomerModel customer)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Created);
            return response;
        }




        public IEnumerable<CustomerModel> GetCustomers()
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
            return theList;
        }





    }
}
