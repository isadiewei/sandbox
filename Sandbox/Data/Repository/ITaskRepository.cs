namespace Sandbox.Repository
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskEntity>> GetAll();
    }
}
