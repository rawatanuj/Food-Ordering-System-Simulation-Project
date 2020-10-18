using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Food_Ordering_System.Models;
using Food_Ordering_System.Helper;
using System.Net.Http;
using Newtonsoft.Json;
using FoodOrderingSystem.Models;
using FoodOrderingSystem.DataAccess.Repository;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace Food_Ordering_System.Controllers
{
    public class HomeController : Controller
    {

        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(HomeController));

        //IRepository<Category> _category;
        /*public HomeController(IRepository<Category> category)
        {
            _category = category;
        }*/
        /* private readonly ILogger<HomeController> _logger;

         public HomeController(ILogger<HomeController> logger)
         {
             _logger = logger;
         }
        */
        Client obj = new Client();
        
        public IActionResult Welcome()
        {
            _log4net.Info("User Login Form");
            return View("Welcome");
        }

        public async Task<IActionResult> Index()
        {

            List<MenuItem> menus = new List<MenuItem>();
            HttpClient client = obj.MenuItemDetails();

            _log4net.Info("MenuItemsApi  Called");

            HttpResponseMessage res = await client.GetAsync("api/MenuItemsApi");

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                menus = JsonConvert.DeserializeObject<List<MenuItem>>(result);
            }
            return View("Index",menus);
        }

        /* public ActionResult Create()
         {
             var viewModel = new MenuItemCategoryViewModel
             {
                 Categories = (List<Category>)_category.GetAll()

             };
             return View("Create", viewModel);
         }

         [HttpPost]
         public IActionResult Add(MenuItemCategoryViewModel menu)
         {
             HttpClient client = obj.MenuItemDetails();
             var postTask = client.PostAsJsonAsync<MenuItem>($"api/MenuItemsApi",menu.MenuItems);
             postTask.Wait();
             var result = postTask.Result;
             if (result.IsSuccessStatusCode)
             {
                 return RedirectToAction("Index");
             }
             return Content("Not Working");
         }
        */

        public IActionResult WelcomeScreen()
        {
            _log4net.Info("Welcome Screen");
            return View("WelcomeScreen");
        }
        public IActionResult Login(UserDetail userModel)
        {

            HttpClient client = obj.AuthClient();
            var contentType = new MediaTypeWithQualityHeaderValue
        ("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);

            /*UserDetail userModel = new UserDetail();
            userModel.Id = 1;
            userModel.UserName = "Anuj";
            userModel.Password = "1234";*/

            string stringData = JsonConvert.SerializeObject(userModel);
            var contentData = new StringContent(stringData,
        System.Text.Encoding.UTF8, "application/json");

            _log4net.Info("Request For Token Generation");

            HttpResponseMessage response = client.PostAsync
        ("/api/AuthApi", contentData).Result;
           
            string stringJWT = response.Content.
        ReadAsStringAsync().Result;

            JWT jwt = JsonConvert.DeserializeObject
        <JWT>(stringJWT);
            if (jwt.Token == null)
                return Content("Wrong Username or Password");
               
            

            HttpContext.Session.SetString("token", jwt.Token);

            /*ViewBag.Message = "User logged in successfully!";

            return View("Index");*/
            //return Content("User Logged in Successfully");
            return RedirectToAction("Index","Category");
        }

        /*public ActionResult GetCurrentSession()
        {
            string s = HttpContext.Session.GetString("token");
            
            return Content(s);
        }
        */
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
    public class JWT
    {
     public string Token { get; set; }
    }
}
