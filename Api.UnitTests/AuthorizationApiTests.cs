using AuthorizationApi;
using AuthorizationApi.Controllers;
using Food_Ordering_System.Models;
using FoodOrderingSystem.DataAccess.Repository;
using FoodOrderingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System;

namespace Api.UnitTests
{
    public class AuthorizationApiTests
    {
        private Mock<IRepository<UserDetail>> _user;
        private Mock<IConfiguration> _config;
        private Mock<IAuthRepo> _auth1;
        private AuthApiController _controller;
        
        [SetUp]
        public void Setup()
        {
             _config = new Mock<IConfiguration>();
             _user= new Mock<IRepository<UserDetail>>();
            _auth1 = new Mock<IAuthRepo>();
             _controller = new AuthApiController(_config.Object, _user.Object,_auth1.Object);
        }

        [Test]
        public void Login_WhenCalled_ReturnsOk()
        {
            UserDetail user = new UserDetail()
            {
                Id = 1,
                UserName = "Anuj",
                Password = "1234"
            };
            _auth1.Setup(r => r.AuthenticateUser(It.IsAny<UserDetail>())).Returns(user);
            _auth1.Setup(r => r.GenerateJSONWebToken()).Returns("Token");

            var result = _controller.Login(user);

            Assert.That(result,Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public void Login_WhenCalled_ReturnsUnAuthorized()
        {
            UserDetail user = new UserDetail()
            {
                Id = 1,
                UserName = "Anuj",
                Password = "1234"
            };
            _auth1.Setup(r => r.AuthenticateUser(It.IsAny<UserDetail>())).Returns(() => null);
            _auth1.Setup(r => r.GenerateJSONWebToken()).Returns("Token");

            var result = _controller.Login(user);

            Assert.That(result, Is.InstanceOf<UnauthorizedResult>());
        }
    }
}