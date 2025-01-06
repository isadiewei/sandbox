using Microsoft.Extensions.Logging;
using Repository.Repository.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Todos
{
    public class TodoService : ITodoService
    {
        private readonly ILogger<TodoService> _logger;
        private readonly ITaskRepository _todoRepository;

        public TodoService(
            ILogger<TodoService> logger,
            ITaskRepository taskRepository
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
    }
}
