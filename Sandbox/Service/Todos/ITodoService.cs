using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Todos
{
    public interface ITodoService
    {
        Task<IEnumerable<Todo>> ReadTodos();
        Task<bool?> CreateTodo(Todo task);
        Task<int?> DeleteTodo(int id);
    }
}
