using FakeItEasy;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Sample_Server.Src.BusinessLogic;
using Sample_Server.Src.Controllers;
using Sample_Server.Src.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Sample_Server.Test.Src.Controllers
{
	public class CustomersControllerTest
	{
        private readonly ILogger<CustomersController> _logger;
        private readonly ICustomersBL _customersBL;
        private readonly CustomersController _customersController;

        public CustomersControllerTest()
        {
            _logger = A.Fake<ILogger<CustomersController>>();
            _customersBL = A.Fake<ICustomersBL>();
            _customersController = new CustomersController(_logger, _customersBL);
        }

        [Fact]
        public void Sample_Server_Get_ReturnListSizeZero()
        {
            A.CallTo(() => _customersBL.getAllCustomers()).Returns(Enumerable.Empty<Customers>());
            Task<ActionResult> response = _customersController.Get();
            var customers = response.Result as OkObjectResult;
            customers.Value.Should().BeEquivalentTo(Enumerable.Empty<Customers>());
        }

        [Fact]
        public void Sample_Server_Get_ReturnListSizeOne()
        {
            Guid guid = new Guid();
            A.CallTo(() => _customersBL.getAllCustomers()).Returns(getTestCustomer(guid));
            Task<ActionResult> response = _customersController.Get();
            var customers = response.Result as OkObjectResult;
            customers.Value.Should().BeEquivalentTo(getTestCustomer(guid));
        }

        [Fact]
        public void Sample_Server_Get_ReturnListSizeTwo()
        {
            Guid guid1 = new Guid();
            Guid guid2 = new Guid();
            A.CallTo(() => _customersBL.getAllCustomers()).Returns(getTestCustomers(guid1, guid2));
            Task<ActionResult> response = _customersController.Get();
            var customers = response.Result as OkObjectResult;
            customers.Value.Should().BeEquivalentTo(getTestCustomers(guid1, guid2));
        }

        [Fact]
        public void Sample_Server_Get_ReturnStatus500()
        {
            A.CallTo(() => _customersBL.getAllCustomers()).Throws(new NullReferenceException());
            Task<ActionResult> response = _customersController.Get();
            var result = response.Result as StatusCodeResult;
            result.StatusCode.Should().Be(StatusCodes.Status500InternalServerError);
        }

        private IEnumerable<Customers> getTestCustomer(Guid guid)
        { 
            IEnumerable<Customers> customer = new[]
            {
                new Customers()
                {
                    Customer_Id = guid,
                    Address = "1234 Reston, VA 22131",
                    First_Name = "Bill",
                    Last_Name = "Murray",
                }
            };

            return customer;
        }

        private IEnumerable<Customers> getTestCustomers(Guid guid1, Guid guid2)
        {
            IEnumerable<Customers> customer = new[]
            {
                new Customers()
                {
                    Customer_Id = guid1,
                    Address = "1234 Reston, VA 22131",
                    First_Name = "Bill",
                    Last_Name = "Murray",
                },
                new Customers()
                {
                    Customer_Id = guid2,
                    Address = "4321 Blacksburg, VA 11223",
                    First_Name = "Tyrod",
                    Last_Name = "Taylor",
                },
            };

            return customer;
        }

    }
}

