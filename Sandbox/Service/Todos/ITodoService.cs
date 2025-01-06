using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Todos
{
    public interface ITodoService
    {
        Task<int?> DeleteTodo(int id);
    }
}
