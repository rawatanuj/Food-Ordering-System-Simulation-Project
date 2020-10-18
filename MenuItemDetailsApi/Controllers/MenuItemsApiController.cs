using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Food_Ordering_System.Models;
using FoodOrderingSystem.DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MenuItemDetailsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemsApiController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(MenuItemsApiController));
        IRepository<MenuItem> _menuitems;
        public MenuItemsApiController(IRepository<MenuItem> menurepo)
        {
            _menuitems = menurepo;
        }
        // GET: api/<MenuItemsApiController>
        [HttpGet]
        public IEnumerable<MenuItem> Get()
        {
            _log4net.Info("Get Api Initiated");
            return  _menuitems.GetAll();
        }

        // GET api/<MenuItemsApiController>/5
        [HttpGet("{id}")]
        public MenuItem Get(int id)
        {
            return _menuitems.Get(id);
        }

        // POST api/<MenuItemsApiController>
        [HttpPost]
        public IActionResult Post(MenuItem menuItem)
        {
            _log4net.Info("Post Api Initiated");
            using (var scope = new TransactionScope())
            {
        
                _menuitems.Add(menuItem);
                scope.Complete();
                //return CreatedAtAction(nameof(Get), new { id = menuItem.Id }, menuItem);
                return Ok();
                
            }
        }

        // PUT api/<MenuItemsApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MenuItemsApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
