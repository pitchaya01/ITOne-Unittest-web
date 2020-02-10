using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnitTest.Web.Domain;
using UnitTest.Web.Model;

namespace UnitTest.Web.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        public DataContext _db;

        public CustomerRepository(DataContext db)
        {
            _db = db;
        }
        public string SaveCustomer(CustomerModel param)
        {
            var c=new Customer();
            c.Name = param.Name;
            c.LastName = param.LastName;
            _db.Customers.Add(c);
            _db.SaveChanges();
            return c.Id.ToString();
        }
    }
}