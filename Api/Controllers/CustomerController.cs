using Api.Dto;
using Api.Validators;
using Domain.Models.Customer;
using Domain.Models.ICustomerContracts;
using Domain.Services;
using Domain.Services.Customer;
using Domain.Services.IServicesContracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Api.Controllers
{
    [EnableCors("*", "*", "*")]
    public class CustomerController : ApiController
    {
        private ICustomerService customerCrudServices = CustomerService.Instance;
        private AnotationValidator<CustomerModel> validator = AnotationValidator<CustomerModel>.Instance;

        public async Task<HttpResponseMessage> GetCustomers()
        {
            try
            {
                IEnumerable<ICustomer> allCustomers = null;
                allCustomers = await this.customerCrudServices.GetAll();
                List<CustomerDto> allCustomersDto = new List<CustomerDto>();
                foreach (ICustomer customer in allCustomers)
                {
                    allCustomersDto.Add(new CustomerDto(customer));
                }
                return Request.CreateResponse(HttpStatusCode.OK, allCustomersDto);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorDto(ex));
            }
        }

        public async Task<HttpResponseMessage> GetCustomer(int id)
        {
            try
            {
                ICustomer customer = await this.customerCrudServices.GetById(id);
                return Request.CreateResponse(HttpStatusCode.OK, new CustomerDto(customer));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorDto(ex));
            }

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
                
                return Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorDto(ex));
            }

        }

        [HttpPut]
        public async Task<HttpResponseMessage> UpdateCustomer(int id, [FromBody] CustomerModel customer)
        {
            try
            {
                await this.customerCrudServices.UpdateById(id, customer);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorDto(ex));
            }
        }
        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteCustomer(int id)
        {
            try
            {
                await this.customerCrudServices.DeleteById(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorDto(ex));
            }
        }
    }
}
