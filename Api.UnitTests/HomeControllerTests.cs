using Food_Ordering_System.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.UnitTests
{
    [TestFixture]
    public class HomeControllerTests
    {

        private HomeController _controller;

        [SetUp]
        public void Setup()
        {
        
            _controller = new HomeController();
        }
       
        [Test]
        public void Welcome_WhenCalled_ReturnsWelcomeView()
        {
            var result = _controller.Welcome() as ViewResult;
            
            Assert.That(result.ViewName, Is.EqualTo("Welcome"));
        }

       /* [Test]
        public void Index_WhenCalled_ReturnsIndexView()
        {
            var result = _controller.Index().Result as ViewResult;

            Assert.That(result.ViewName, Is.EqualTo("Index"));
        }
       */
        [Test]
        public void WelcomeScreen_WhenCalled_ReturnsWelcomeScreenView()
        {
            var result = _controller.WelcomeScreen() as ViewResult;

            Assert.That(result.ViewName, Is.EqualTo("WelcomeScreen"));
        }
    }
}
