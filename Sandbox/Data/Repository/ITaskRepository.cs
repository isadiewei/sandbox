using Model;

namespace Sandbox.Repository
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskEntity>> GetAll();
        Task<int?> CreateTodo(Todo todo);
    }
}
