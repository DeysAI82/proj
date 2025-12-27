using proj.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proj.Interfaces
{
    public interface IRepository<T>
    {
        public void Add(User user);
        public void Delete(int id);
        public void Update(int id, User user);
        public T? Get(int id);
        public IEnumerable<T> GetAll();
        public T? Find(Predicate<T> predicate);
    }
}
