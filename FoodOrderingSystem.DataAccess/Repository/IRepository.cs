using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingSystem.DataAccess.Repository
{
    public interface IRepository<T>
    {
        void Add(T item);
        void Update(T item);
        void Delete(int id);
        T Get(int id);
        IEnumerable<T> GetAll();
    }
}
