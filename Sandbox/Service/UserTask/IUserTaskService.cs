using Model;

namespace Service.UserTask
{
    public interface IUserTaskService
    {
        Task<IEnumerable<Todo>> GetAll();
        Task<bool?> CreateTodo(Todo task);
        Task<IEnumerable<Todo>> GetUserTasks(int? userId);
    }
}
