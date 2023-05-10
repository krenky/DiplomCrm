using Microsoft.VisualStudio.TestTools.UnitTesting;
using webapi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webapi.Data;
using webapi.Interfaсe;
using webapi.Models;

namespace webapi.Services.Tests
{
    [TestClass()]
    public class CustomerServiceTests
    {
        ICustomerService service;

        public CustomerServiceTests(ICustomerService service)
        {
            this.service = service;
        }

        [TestMethod()]
        public void CustomerServiceTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public async void AddCustomerTest()
        {
            try
            {
                Customer customer = new Customer()
                {
                    FirstName = "sergey",
                    LastName = "nazarov",
                    Phone = "0",
                    Email = "Nazaroff.sere",
                    Address = "kazan",
                    Birthdate = new DateTime(2001, 4, 3)
                };
                Customer addingCustomer = await service.AddCustomer(customer);
                Assert.IsTrue(addingCustomer.Id != 0);
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void ChangeCustomerTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteCustomerTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetCustomerTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetCustomersTest()
        {
            Assert.Fail();
        }
    }
}