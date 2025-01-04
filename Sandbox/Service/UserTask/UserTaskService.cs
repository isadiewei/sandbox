using Microsoft.Extensions.Logging;
using Model;
using Model.Exceptions;
using Repository.Repository.Task;
using Repository.Repository.UserTask;

namespace Service.UserTask
{
    public class UserTaskService : IUserTaskService
    {
        private readonly ILogger<UserTaskService> _logger;
        private readonly ITaskRepository _taskRepo;
        private readonly IUserTaskRepository _userTaskRepository;

        public UserTaskService(
            ILogger<UserTaskService> logger,
            ITaskRepository taskRepo,
            IUserTaskRepository userTaskRepository
            )
        {
            _logger = logger;
            _taskRepo = taskRepo;
            _userTaskRepository = userTaskRepository;
        }

        public async Task<IEnumerable<Todo>> GetAll()
        {
            try
            {
                IEnumerable<Todo> tasks = await _taskRepo.GetAll();

                return tasks;
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
                int? result = await _taskRepo.InsertTodo(todo);

                return result.HasValue && result.Value > 0;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "failed to create task");
                return null;
            }
        }

        public async Task<IEnumerable<Todo>> GetUserTasks(int? userId)
        {
            try
            {
                if (!userId.HasValue)
                {
                    _logger.LogWarning($"get user tasks will not be found for id {userId}");
                }

                IEnumerable<Todo>? todos = await _userTaskRepository.GetAll(
                    new User { UserId = userId.Value });

                if (todos == null)
                {
                    _logger.LogWarning($"user tasks returned null tasks for user {userId}");
                    return [];
                }

                return todos;
            }
            catch (Exception e)
            {
                _logger.LogError(e, message: $"failed to get user tasks for user {userId}");
                return [];
            }
        }
    }
}
