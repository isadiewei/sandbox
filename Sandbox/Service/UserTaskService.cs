using Sandbox.Repository;
using Model;
using Model.Exceptions;

namespace Service
{
    public class UserTaskService : IUserTaskService
    {
        private readonly ITaskRepository _taskRepo;

        public UserTaskService(ITaskRepository taskRepo)
        {
            _taskRepo = taskRepo;
        }

        public async Task<IEnumerable<Todo>> GetAll()
        {
            try
            {
                IEnumerable<TaskEntity> tasks = await _taskRepo.GetAll();

                return tasks.Select(t => new Todo
                {
                    TaskId = t.TaskId,
                    Name = t.Name,
                    Description = t.Description,
                });
            }
            catch (Exception e)
            {
                throw new SelectException("Error Mapping Task to Todo", e);
            }
        }
    }
}
