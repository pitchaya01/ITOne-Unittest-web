using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnitTest.Web.Model
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public List<int> ProductIds { get; set; }


    }
}