using Model;

namespace Repository.Repository.UserTodos
{
    public interface IUserTodosRepository
    {
        Task<IEnumerable<Todo>?> GetAll(User user);
    }
}
