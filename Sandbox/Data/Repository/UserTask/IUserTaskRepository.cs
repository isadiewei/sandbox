using Model;

namespace Repository.Repository.UserTask
{
    public interface IUserTaskRepository
    {
        Task<IEnumerable<Todo>?> GetAll(User user);
    }
}
