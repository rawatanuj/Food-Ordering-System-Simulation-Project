using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodOrderingSystem.DataAccess.Repository;
using FoodOrderingSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AuthorizationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthApiController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(AuthApiController));

        private IConfiguration _config;
        IRepository<UserDetail> _userdetails;
        IAuthRepo _auth;
        public AuthApiController(IConfiguration config, IRepository<UserDetail> userdetails, IAuthRepo auth)
        {
            _config = config;
            _userdetails = userdetails;
            _auth = auth;
        }


        /* [Authorize]
         [HttpGet("{id}")]
         public string  Get(int id)
         {
             return "abc";
         }
        */
        [HttpPost]
        // [HttpGet]
        public IActionResult Login(UserDetail userdetail)
        {
            /*user.Id = 1;
            user.UserName = "Anuj";
            user.Password = "1234";*/
            _log4net.Info("Authentication initiated");
            IActionResult response = Unauthorized();
            var user = _auth.AuthenticateUser(userdetail);

            if (user != null)
            {
                var tokenString = _auth.GenerateJSONWebToken();
                response = Ok(new { token = tokenString });
            }

            // return response;
            /* var tokenString = GenerateJSONWebToken();
             response = Ok(new { token = tokenString });
             // return Ok(GenerateJSONWebToken());*/
            return response;
        }
       /* private string GenerateJSONWebToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                null,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
       
        private UserDetail AuthenticateUser(UserDetail userdetail)
        {
           
            var userdetailslist = _userdetails.GetAll();
            foreach (var i in userdetailslist)
            {
                if (i.UserName == userdetail.UserName && i.Password == userdetail.Password)
                    return userdetail;
            }
            return null;

        }
       */
    }
}
