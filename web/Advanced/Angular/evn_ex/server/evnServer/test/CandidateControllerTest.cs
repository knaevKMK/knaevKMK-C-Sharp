
namespace test
{
    using System;
    using System.Collections.Generic;
    using evnServer.Controllers;
    using evnServer.Model.Binding;
    using evnServer.Validation;
    using evnServer.Model.View;
    using Moq;
    using NUnit.Framework;
    using Microsoft.AspNetCore.Mvc;
    using evnServer.Service;
    using System.Threading.Tasks;

    public class Tests
    {
        CandidateController controller;
       [SetUp]
        public void Setup()
        {
            var mockService = new Mock<IUserService>();
            controller = new CandidateController(
                         new UserCreatDtoValidation(),
                      mockService.Object
                         );
        }

        [Test]
        public  void Ctr_GetAll()
        {

            var result = controller.All();
            Assert.IsAssignableFrom(typeof(Task<ActionResult<List<UserViewModel>>>), result);
            Assert.IsAssignableFrom(typeof(ActionResult<List<UserViewModel>>), result.Result);
            Assert.IsAssignableFrom(typeof(OkObjectResult), result.Result.Result);
        }

        [Test]
        public void Ctr_Create_Candidate() {
            UserCreateDto              userModel = new UserCreateDto()
              {
                  FullName = "Krasen",
                  DepartmentName = "CI",
                  Education = "Tap tap",
                  Score = 5,
                  BirthDate = DateTime.Parse("1984/11/04")
              };

            var result = controller.Create(userModel);
            Assert.IsAssignableFrom(typeof(Task<ActionResult>), result);
            Assert.IsAssignableFrom(typeof(CreatedResult), result.Result);
           
        }
        [Test]
        public void Ctr_Return_BadRequest_On_Null_Field_Or_DTO() {
            var result = controller.Create(new UserCreateDto());
            Assert.IsAssignableFrom(typeof(Task<ActionResult>), result);
            Assert.IsAssignableFrom(typeof(BadRequestObjectResult),result.Result);
        }
        [Test]
        public void Ctr_Return_BadRequest_On_NOT_EXIST_DEPART() {
           var result = controller.Create(new UserCreateDto()
            {
                FullName = "Krasen",
                DepartmentName = "IVAN",
                Education = "Tap tap",
                Score = 5,
                BirthDate = DateTime.Parse("1984/11/04")
            });
            Assert.IsAssignableFrom(typeof(Task<ActionResult>), result);
            Assert.IsAssignableFrom(typeof(BadRequestObjectResult), result.Result);
        }

        [Test]
        public void Ctr_Return_SortList_By_FieldName()
        {
           var result = controller.Sort("name asc");
            Assert.IsAssignableFrom(typeof(Task<ActionResult<List<UserViewModel>>>), result);
            Assert.IsAssignableFrom(typeof(ActionResult<List<UserViewModel>>), result.Result);
            Assert.IsAssignableFrom(typeof(OkObjectResult), result.Result.Result);
        }

        [Test]
        public void Ctr_Return_FilterList_By_FieldName()
        {
            var result = controller.filter(new FilterDto { Name = "Ivan" });
            Assert.IsAssignableFrom(typeof(Task<ActionResult<List<UserViewModel>>>), result);
            Assert.IsAssignableFrom(typeof(ActionResult<List<UserViewModel>>), result.Result);
            Assert.IsAssignableFrom(typeof(OkObjectResult), result.Result.Result);
        }
        [Test]
        public void Ctr_Return_FilterList_Without_FieldName_WILL_NOT_THROW()
        {
            var result = controller.filter(new FilterDto());
            Assert.IsAssignableFrom(typeof(Task<ActionResult<List<UserViewModel>>>), result);
            Assert.IsAssignableFrom(typeof(ActionResult<List<UserViewModel>>), result.Result);
            Assert.IsAssignableFrom(typeof(OkObjectResult), result.Result.Result);
        }
    }
}