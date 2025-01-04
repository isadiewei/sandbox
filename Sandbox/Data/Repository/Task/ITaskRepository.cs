using Model;

namespace Repository.Repository.Task
{
    public interface ITaskRepository
    {
        Task<IEnumerable<Todo>> GetAll();
        Task<int?> InsertTodo(Todo todo);
    }
}
