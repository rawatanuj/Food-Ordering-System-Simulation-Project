using Food_Ordering_System.Data;
using Food_Ordering_System.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingSystem.DataAccess.Repository
{
    public class MenuItemRepository : IRepository<MenuItem>
    {

        private readonly ApplicationDbContext _context;
        public MenuItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(MenuItem item)
        {
            _context.MenuItems.Add(item);
            _context.SaveChanges();
           
        }

        public void Delete(int id)
        {
            var obj =  _context.MenuItems.Find(id);
            _context.MenuItems.Remove(obj);
            _context.SaveChanges();
        }

        public MenuItem Get(int id)
        {
            return _context.MenuItems.Find(id);

        }

        public IEnumerable<MenuItem> GetAll()
        {
            return _context.MenuItems.Include(c => c.Category).ToList();

        }

        public void Update(MenuItem item)
        {
            _context.Update(item);
            _context.SaveChangesAsync();
        }
    }
}
