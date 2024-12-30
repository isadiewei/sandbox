using Sandbox.Repository;
using Model;
using Model.Exceptions;
using Microsoft.Extensions.Logging;

namespace Service.UserTask
{
    public class UserTaskService : IUserTaskService
    {
        private readonly ILogger<UserTaskService> _logger;
        private readonly ITaskRepository _taskRepo;

        public UserTaskService(
            ILogger<UserTaskService> logger,
            ITaskRepository taskRepo
            )
        {
            _logger = logger;
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

        public async Task<bool?> CreateTodo(Todo todo)
        {
            try
            {
                int? result = await _taskRepo.CreateTodo(todo);

                return result.HasValue && result.Value > 0;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "failed to create task");
                return null;
            }
        }
    }
}
