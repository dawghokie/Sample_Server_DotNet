using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sample_Server.Src.BusinessLogic;
using Sample_Server.Src.Controllers;
using Sample_Server.Src.DataAccess;
using Sample_Server.Src.Models;
using Sample_Server.Test.Src.Utils;

namespace Sample_Server.Test.Src.Controllers
{
	public class OrdersControllerTest
	{
        private readonly ILogger<OrdersController> _logger;
        private readonly IOrdersBL ordersBL;
        private readonly OrdersController ordersController;

        public OrdersControllerTest()
        {
            _logger = A.Fake<ILogger<OrdersController>>();
            ordersBL = A.Fake<IOrdersBL>();
            ordersController = new OrdersController(_logger, ordersBL);
        }

        [Fact]
        public void OrdersController_Get_ReturnListSizeZero()
        {
            A.CallTo(() => ordersBL.getAllOrders()).Returns(Enumerable.Empty<Orders>());
            Task<ActionResult> response = ordersController.Get();
            var orders = response.Result as OkObjectResult;
            orders.Value.Should().BeEquivalentTo(Enumerable.Empty<Customers>());
        }


        [Fact]
        public void OrdersController_Get_ReturnListSizeOne()
        {
            Guid guid1 = new Guid();
            Guid guid2 = new Guid();
            A.CallTo(() => ordersBL.getAllOrders()).Returns(TestDataUtils.getTestOrder(guid1, guid2));
            Task<ActionResult> response = ordersController.Get();
            var order = response.Result as OkObjectResult;
            order.Value.Should().BeEquivalentTo(TestDataUtils.getTestOrder(guid1, guid2));
        }

        [Fact]
        public void OrdersController_Get_ReturnListSizeTwo()
        {
            Guid guid1 = new Guid();
            Guid guid2 = new Guid();
            Guid guid3 = new Guid();
            Guid guid4 = new Guid();
            A.CallTo(() => ordersBL.getAllOrders()).Returns(TestDataUtils.getTestOrders(guid1, guid2, guid3, guid4));
            Task<ActionResult> response = ordersController.Get();
            var orders = response.Result as OkObjectResult;
            orders.Value.Should().BeEquivalentTo(TestDataUtils.getTestOrders(guid1, guid2, guid3, guid4));
        }

        [Fact]
        public void OrdersController_Get_ReturnStatus500()
        {
            A.CallTo(() => ordersBL.getAllOrders()).Throws(new NullReferenceException());
            Task<ActionResult> response = ordersController.Get();
            var result = response.Result as StatusCodeResult;
            result.StatusCode.Should().Be(StatusCodes.Status500InternalServerError);
        }
    }
}

