using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zablo.Models;

namespace zablo.Domains
{
    public interface ITodoRepository
    {
        void Add(TodoItem item);
        IEnumerable<TodoItem> GetAll();
        TodoItem Find(string key);
        TodoItem Remove(string key);
        void Update(TodoItem item);
    }
}
