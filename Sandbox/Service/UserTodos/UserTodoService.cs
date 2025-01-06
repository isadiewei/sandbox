using Microsoft.Extensions.Logging;
using Model;
using Model.Exceptions;
using Repository.Repository.Todos;
using Repository.Repository.UserTodos;

namespace Service.UserTodos
{
    public class UserTodoService : IUserTodoService
    {
        private readonly ILogger<UserTodoService> _logger;
        private readonly ITodoRepository _taskRepo;
        private readonly IUserTodosRepository _userTaskRepository;

        public UserTodoService(
            ILogger<UserTodoService> logger,
            ITodoRepository taskRepo,
            IUserTodosRepository userTaskRepository
            )
        {
            _logger = logger;
            _taskRepo = taskRepo;
            _userTaskRepository = userTaskRepository;
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
