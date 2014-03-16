using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Data.Queries;
using Domain.Entities;
using Highway.Data;
using Highway.Data.Contexts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using UI;
using UI.Controllers;

namespace UI.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DetailsByNameShouldGetDataFromRepository()
        {
            //Arrange
            var repository = MockRepository.GenerateMock<IRepository>();
            repository.Expect(x => x.Find(Arg<CourseByName>.Is.Anything))
                .Return(new Course()
                {
                    Name = "Testing"
                });
            var target = new HomeController(repository);

            //Act
            var result = target.Details("Testing");

            //Assert
            repository.VerifyAllExpectations();
        }

        [TestMethod]
        public void DetailsByNameShouldGetDataFromRepositorySecondWay()
        {
            //Arrange
            var repository = new Repository(new InMemoryDataContext());
            repository.Context.Add(new Course() {Name = "Testing"});

            var target = new HomeController(repository);

            //Act
            var result = target.Details("Testing");

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CourseByNameShouldFilterOnName()
        {
            //Arrange
            var context = MockRepository.GenerateMock<IDataContext>();
            context.Expect(x => x.AsQueryable<Course>())
                .Return(new List<Course>
                {
                    new Course {Name = "Testing"},
                    new Course {Name = "ShouldNotMatch"}
                }.AsQueryable());

            //Act
            var result = new CourseByName("Testing").Execute(context);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Testing", result.Name);
        }

        [TestMethod]
        public void CourseByNameShouldFilterOnNameSecondWay()
        {
            //Arrange
            var context = new InMemoryDataContext();
            context.Add(new Course {Name = "Testing"});
            context.Add(new Course {Name = "ShouldNotMatch"});

            //Act
            var result = new CourseByName("Testing").Execute(context);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Testing", result.Name);
        }
    }
}
