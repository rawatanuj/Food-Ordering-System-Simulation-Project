using Food_Ordering_System.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.UnitTests
{
    [TestFixture]
    public class CategoryControllerTests
    {
        private CategoryController _controller;

        [SetUp]
        public void Setup()
        {
            _controller = new CategoryController();
        }

        [Test]
        public void Create_WhenCalled_ReturnsCreateView()
        {
            var result = _controller.Create() as ViewResult;

            Assert.That(result.ViewName, Is.EqualTo("Create"));
        }
    }
}
