using Food_Ordering_System.Data;
using FoodOrderingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodOrderingSystem.DataAccess.Repository
{
    public class UserRepository : IRepository<UserDetail>
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(UserDetail item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public UserDetail Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDetail> GetAll()
        {
            return _context.UserDetails.ToList();
        }

        public void Update(UserDetail item)
        {
            throw new NotImplementedException();
        }
    }
}
