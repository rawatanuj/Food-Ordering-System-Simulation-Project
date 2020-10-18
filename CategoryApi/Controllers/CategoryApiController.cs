using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Food_Ordering_System.Models;
using FoodOrderingSystem.DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CategoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryApiController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(CategoryApiController));

        IRepository<Category> _category;
        public CategoryApiController(IRepository<Category> categoryrepo)
        {
            _category = categoryrepo;
        }

        // GET: api/<CategoryApiController>
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            _log4net.Info("Get initiated");
            return _category.GetAll();
        }

        // GET api/<CategoryApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CategoryApiController>
        [HttpPost]
        public IActionResult Post(Category category)
        {
            _log4net.Info("Post initiated");
            using (var scope = new TransactionScope())
            {
                _category.Add(category);
                scope.Complete();
                //return CreatedAtAction(nameof(Get), new { id = menuItem.Id }, menuItem);
                return Ok();
            }
        }

        // PUT api/<CategoryApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoryApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
