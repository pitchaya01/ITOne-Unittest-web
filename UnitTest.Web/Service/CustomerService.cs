using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Design;
using System.Linq;
using System.Web;
using FluentValidation;
using UnitTest.Web.Model;
using UnitTest.Web.Repository;
using UnitTest.Web.Validator;

namespace UnitTest.Web.Service
{
    public class CustomerService : ICustomerService
    {
        public ICustomerRepository _CustomerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _CustomerRepository = customerRepository;
        }
        public string SaveCustomer(CustomerModel param)
        {
            CustomerModelValidator validator=new CustomerModelValidator();
            validator.ValidateAndThrow(param);
            var c=_CustomerRepository.SaveCustomer(param);
            return c;
        }
    }
}