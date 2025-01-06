using Model;

namespace Service.UserTodos
{
    public interface IUserTodoService
    {
        Task<IEnumerable<Todo>> GetUserTasks(int? userId);
    }
}
