using Model;

namespace Repository.Repository.Todos
{
    public interface ITodoRepository
    {
        Task<IEnumerable<Todo>> ReadTodo();
        Task<int?> InsertTodo(Todo todo);
        Task<int?> DeleteTodo(Todo todo);
    }
}
