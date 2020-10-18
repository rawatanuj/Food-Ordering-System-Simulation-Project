using FoodOrderingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationApi
{
    public interface IAuthRepo
    {
        //IActionResult Login(UserDetail userdetail);
        string GenerateJSONWebToken();

        UserDetail AuthenticateUser(UserDetail userdetail);
    }
}
