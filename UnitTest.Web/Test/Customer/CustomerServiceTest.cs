using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTest.Web.Test.Customer
{
    [TestClass]
    public class CustomerServiceTest
    {
        [TestMethod]
        public void CustomerSave_Return_Success()
        {
            var a = "a";
            Assert.NotNull(a);
        }
    }
}