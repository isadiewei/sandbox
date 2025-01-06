using Microsoft.Extensions.Logging;
using Model;
using Model.Exceptions;
using Repository.Repository.Todos;

namespace Service.Todos
{
    public class TodoService : ITodoService
    {
        private readonly ILogger<TodoService> _logger;
        private readonly ITodoRepository _todoRepository;

        public TodoService(
            ILogger<TodoService> logger,
            ITodoRepository taskRepository
            )
        {
            _logger = logger;
            _todoRepository = taskRepository;
        }

        public async Task<int?> DeleteTodo(int id)
        {
            try
            {
                int? result = await _todoRepository.DeleteTodo(new Model.Todo { TaskId = id });

                if (result == null)
                {
                    _logger.LogTrace("failed to find todo");
                    return result;
                }

                _logger.LogTrace($"deleted todo item {id}");
                return result;
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"failed to delete todo {id}");
                return null;
            }
        }

        public async Task<IEnumerable<Todo>> ReadTodos()
        {
            try
            {
                IEnumerable<Todo> tasks = await _todoRepository.ReadTodo();

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
                int? result = await _todoRepository.InsertTodo(todo);

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
