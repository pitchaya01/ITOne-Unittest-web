using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnitTest.Web.Model;

namespace UnitTest.Web.Service
{
    public interface ICustomerService
    {
        string SaveCustomer(CustomerModel param);

    }
}