using FakeItEasy;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Sample_Server.Src.BusinessLogic;
using Sample_Server.Src.Controllers;
using Sample_Server.Src.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Sample_Server.Test.Src.Utils;

namespace Sample_Server.Test.Src.Controllers
{
	public class CustomersControllerTest
	{
        private readonly ILogger<CustomersController> _logger;
        private readonly ICustomersBL customersBL;
        private readonly CustomersController customersController;

        public CustomersControllerTest()
        {
            _logger = A.Fake<ILogger<CustomersController>>();
            customersBL = A.Fake<ICustomersBL>();
            customersController = new CustomersController(_logger, customersBL);
        }

        [Fact]
        public void CustomersController_Get_ReturnListSizeZero()
        {
            A.CallTo(() => customersBL.getAllCustomers()).Returns(Enumerable.Empty<Customers>());
            Task<ActionResult> response = customersController.Get();
            var customers = response.Result as OkObjectResult;
            customers.Value.Should().BeEquivalentTo(Enumerable.Empty<Customers>());
        }

        [Fact]
        public void CustomersController_Get_ReturnListSizeOne()
        {
            Guid guid = new Guid();
            A.CallTo(() => customersBL.getAllCustomers()).Returns(TestDataUtils.getTestCustomer(guid));
            Task<ActionResult> response = customersController.Get();
            var customers = response.Result as OkObjectResult;
            customers.Value.Should().BeEquivalentTo(TestDataUtils.getTestCustomer(guid));
        }

        [Fact]
        public void CustomersController_Get_ReturnListSizeTwo()
        {
            Guid guid1 = new Guid();
            Guid guid2 = new Guid();
            A.CallTo(() => customersBL.getAllCustomers()).Returns(TestDataUtils.getTestCustomers(guid1, guid2));
            Task<ActionResult> response = customersController.Get();
            var customers = response.Result as OkObjectResult;
            customers.Value.Should().BeEquivalentTo(TestDataUtils.getTestCustomers(guid1, guid2));
        }

        [Fact]
        public void CustomersController_Get_ReturnStatus500()
        {
            A.CallTo(() => customersBL.getAllCustomers()).Throws(new NullReferenceException());
            Task<ActionResult> response = customersController.Get();
            var result = response.Result as StatusCodeResult;
            result.StatusCode.Should().Be(StatusCodes.Status500InternalServerError);
        }
    }
}

