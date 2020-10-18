using CategoryApi.Controllers;
using Food_Ordering_System.Models;
using FoodOrderingSystem.DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.UnitTests
{
    [TestFixture]
    public class CategoryApiTests
    {
        private Mock<IRepository<Category>> _category;
        private CategoryApiController _controller;

        [SetUp]
        public void Setup()
        {
            _category = new Mock<IRepository<Category>>();
            _controller = new CategoryApiController(_category.Object);
        }

        [Test]
        public void Get_WhenCalled_ReturnsListOfCategories()
        {

            _category.Setup(repo => repo.GetAll()).Returns(new List<Category> {new Category()
                {
                    Id = 1,
                    Name = "Soup"
                    
                } });

            var result = _controller.Get();


            Assert.That(result.Count, Is.EqualTo(1));
        }

        [Test]
        public void Post_WhenCalled_ReturnsOk()
        {

            _category.Setup(repo => repo.Add(It.IsAny<Category>())).Verifiable();

            var result = _controller.Post(new Category { });


            //Assert.AreEqual(200,result.StatusCode);
            Assert.That(result, Is.TypeOf<OkResult>());
        }
    }

}

