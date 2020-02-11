using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTest.Web.Service;
using Moq;
using System.Data.Entity;
using UnitTest.Web.Domain;
using UnitTest.Web.Repository;
using UnitTest.Web.Model;
using System;

namespace UnitTest.Test
{
    [TestClass]
    public class CustomerServiceTest
    {
        private Mock<DataContext> mockDbContext;
        private Mock<DbSet<Customer>> mockCustomerDbSet;
        [TestInitialize]
        public void InititalObject()
        {
            this.mockDbContext= new Mock<DataContext>();
            this.mockCustomerDbSet = new Mock<DbSet<Customer>>();
            this.mockDbContext.Setup(a => a.Customers).Returns(mockCustomerDbSet.Object);
        }
        public ICustomerService _CustomerService;
        [TestMethod]
        public void CustomerSave_Return_Success()
        {
            var customerRepo = new CustomerRepository(mockDbContext.Object);

            var data = new CustomerModel();
            data.Name = "hack";
            data.LastName = "k";
            data.ProductIds = new System.Collections.Generic.List<int>();
            data.ProductIds.Add(7);


            var service = new CustomerService(customerRepo);
            var resut = service.SaveCustomer(data);
            mockCustomerDbSet.Verify(m => m.Add(It.IsAny<Customer>()));
            mockDbContext.Verify(m => m.SaveChanges(), Times.Once());
            Assert.IsNotNull(resut);
        }
        [TestMethod]
        public void CustomerSave_ValidateField_Return_Success()
        {
            var data = new CustomerModel();
            data.Name = "hack";
            data.LastName = "k";
            data.ProductIds = new System.Collections.Generic.List<int>();
            data.ProductIds.Add(7);

            var _mockCustomerRepo = new Mock<ICustomerRepository>();
            var service = new CustomerService(_mockCustomerRepo.Object);
            service.SaveCustomer(data);
        }
        [TestMethod]
        [ExpectedException(typeof(FluentValidation.ValidationException),AllowDerivedTypes =false)]
        public void CustomeSave_ValidateField_Return_Exception()
        {
            var data = new CustomerModel();
            data.Name = "hack";
            data.LastName = "k";
            data.ProductIds = new System.Collections.Generic.List<int>();

            var _mockCustomerRepo = new Mock<ICustomerRepository>();
            var service = new CustomerService(_mockCustomerRepo.Object);
            service.SaveCustomer(data);
        }
        [TestCleanup]
        public void ClearObjectMock()
        {
            this.mockCustomerDbSet = null;
            this.mockDbContext = null;
        }
        
    }
            
}
