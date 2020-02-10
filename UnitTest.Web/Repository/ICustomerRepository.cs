using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnitTest.Web.Model;

namespace UnitTest.Web.Repository
{
    public interface ICustomerRepository
    {
        string SaveCustomer(CustomerModel param);
    }
}