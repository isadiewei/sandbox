using Model;

namespace Service
{
    public interface IUserTaskService
    {
        Task<IEnumerable<Todo>> GetAll();
    }
}
