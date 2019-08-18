using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomerInquiry.Controllers;
using CustomerInquiry.Models;
using System.Web.Http.Results;

namespace CustomerInquiry.Tests
{
    [TestClass]
    public class TestCustomerController
    {
        [TestMethod]
        public void ValidateEmail_ShouldReturn_Invalid()
        {
            var controller = new CustomersController(new TestCustomerInquiryContext());
            var badresult = controller.SearchCustomer(new Requests.CustomerRequest()
            {
                Email = "khanit05gmail.com",
            });          
           
            Assert.IsInstanceOfType(badresult, typeof(BadRequestErrorMessageResult));

        }
       
        [TestMethod]
        public void GetCustomerById_ShouldReturn_NO_Transaction()
        {
            var controller = new CustomersController(new TestCustomerInquiryContext());
            var result = controller.SearchCustomer(new Requests.CustomerRequest()
            {
                Id = 2,
            }) as OkNegotiatedContentResult<Customer>;

            Assert.IsNotNull(result);
            Assert.AreEqual(null, result.Content.Transactions);

        }

        [TestMethod]
        public void GetCustomerById_ShouldReturn_1_Transaction()
        {
            var controller = new CustomersController(new TestCustomerInquiryContext());
            var result = controller.SearchCustomer(new Requests.CustomerRequest()
            {
                Id =1,
            }) as OkNegotiatedContentResult<Customer>;

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Content.Transactions.Count);

        }
        [TestMethod]
        public void GetCustomerById_ShouldReturn_Multi_Transaction()
        {
            var controller = new CustomersController(new TestCustomerInquiryContext());
            var result = controller.SearchCustomer(new Requests.CustomerRequest()
            {
                Id = 3,
            }) as OkNegotiatedContentResult<Customer>;

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Content.Transactions.Count > 1, "Return multi transcation");
           

        }


        [TestMethod]
        public void GetCustomerOnlyID_ShouldReturn_CustomerA()
        {
            var controller = new CustomersController(new TestCustomerInquiryContext());
            var result = controller.SearchCustomer(new Requests.CustomerRequest()
            {
                Id = 1,         
            }) as OkNegotiatedContentResult<Customer>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content.Id,1);


        }    
        [TestMethod]
        public void GetCustomerOnlyEmail_ShouldReturn_CustomerA()
        {
            var testEmail = "userA@domain.com";
            var controller = new CustomersController(new TestCustomerInquiryContext());
            var result = controller.SearchCustomer(new Requests.CustomerRequest()
            {
                Email = testEmail
            }) as OkNegotiatedContentResult<Customer>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content.Email, testEmail);


        }

        [TestMethod]
        public void GetCustomerByEmailAndID_ShouldReturn_CustomerA()
        {
            var controller = new CustomersController(new TestCustomerInquiryContext());
            var testEmail = "userA@domain.com";
            var result = controller.SearchCustomer(new Requests.CustomerRequest()
            {
                Id = 1,
                Email = testEmail
            }) as OkNegotiatedContentResult<Customer>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content.Email, testEmail);
            Assert.AreEqual(result.Content.Id, 1);

        }    


        
    }
}
