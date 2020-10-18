using Food_Ordering_System.Models;
using FoodOrderingSystem.DataAccess.Repository;
using MenuItemDetailsApi.Controllers;
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
    public class MenuItemsApiTests
    {
        private Mock<IRepository<MenuItem>> _menu;
        private MenuItemsApiController _controller;

        [SetUp]
        public void Setup()
        {
           _menu = new Mock<IRepository<MenuItem>>();
            _controller = new MenuItemsApiController(_menu.Object);
        }

        [Test]
        public void Get_WhenCalled_ReturnsListOfMenuItems()
        {
            
            _menu.Setup(repo => repo.GetAll()).Returns(new List<MenuItem> {new MenuItem()
                {
                    Id = 1,
                    Name = "Soup",
                    Price = 150,
                    Active = true,
                    DateOfLaunch = Convert.ToDateTime("2002-12-12 12:12:00.0000000"),
                    CategoryId = 1,
                    FreeDelivery = true
                } });

            var result = _controller.Get();


            Assert.That(result.Count, Is.EqualTo(1));
        }

        [Test]
        public void Post_WhenCalled_ReturnsOk()
        {

            _menu.Setup(repo => repo.Add(It.IsAny<MenuItem>())).Verifiable();

            var result = _controller.Post(new MenuItem { });


            //Assert.AreEqual(200,result.StatusCode);
            Assert.That(result, Is.TypeOf<OkResult>());
        }
    }
}
