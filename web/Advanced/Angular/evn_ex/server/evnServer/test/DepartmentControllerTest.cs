
namespace test
{
    using evnServer.Controllers;
    using evnServer.Model.View;
    using evnServer.Service;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using NUnit.Framework;
    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    class DepartmentControllerTest
    {

        DepartmentController controller;
        [SetUp]
        public void Setup() {
            var mockService = new Mock<IDepartmentService>();
            controller = new DepartmentController(mockService.Object);
        }

        [Test]
        public void Ctr_Get_All()
        {
            var result = controller.All();
            Assert.IsAssignableFrom(typeof(Task<ActionResult<List<DepartmentViewModel>>>),result);
            Assert.IsAssignableFrom(typeof(ActionResult<List<DepartmentViewModel>>),result.Result);
            Assert.IsAssignableFrom(typeof(OkObjectResult),result.Result.Result);
        }
    }
}
