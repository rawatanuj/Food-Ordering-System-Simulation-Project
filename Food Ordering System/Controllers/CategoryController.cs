using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Food_Ordering_System.Helper;
using Food_Ordering_System.Models;
using FoodOrderingSystem.DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Food_Ordering_System.Controllers
{
    public class CategoryController : Controller
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(CategoryController));

        /*IRepository<Category> _category;
        public CategoryController(IRepository<Category> category)
        {
            _category = category;
        }
        */
        Client obj = new Client();
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("token") == null)
                return RedirectToAction("Welcome","Home");

            List<Category> category = new List<Category>();
            HttpClient client = obj.CategoryDetails();

            _log4net.Info("CategoryApi  Called");

            HttpResponseMessage res = await client.GetAsync("api/CategoryApi");

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                category = JsonConvert.DeserializeObject<List<Category>>(result);
            }
            return View(category);
        }

        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
         public IActionResult Add(Category category)
         {
             HttpClient client = obj.CategoryDetails();

            _log4net.Info("Post request to Category Api");

            var postTask = client.PostAsJsonAsync<Category>($"api/CategoryApi", category);
             postTask.Wait();
             var result = postTask.Result;
             if (result.IsSuccessStatusCode)
             {
                 return RedirectToAction("Index");
             }
             return Content("Not Working");
         }

    }
}
