using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FluentValidation;
using UnitTest.Web.Model;
using UnitTest.Web.Service;
using UnitTest.Web.Validator;

namespace UnitTest.Web.Controllers
{
    public class CustomerController : ApiController
    {
        public ICustomerService _CustomerService;

        public CustomerController(ICustomerService customerService)
        {
            _CustomerService = customerService;
        }
        
        [HttpPost]
        public string Save(CustomerModel param)
        {
            
            CustomerModelValidator validator = new CustomerModelValidator();
            validator.ValidateAndThrow(param);
            return _CustomerService.SaveCustomer(param);
        }
    }
}
