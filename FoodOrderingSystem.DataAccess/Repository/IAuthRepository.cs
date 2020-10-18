using FoodOrderingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingSystem.DataAccess.Repository
{
    public interface IAuthRepository
    {
        IActionResult Login(UserDetail userdetail);
        string GenerateJSONWebToken();

        UserDetail AuthenticateUser(UserDetail userdetail);
    }
}
