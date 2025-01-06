using Dapper;
using Microsoft.Extensions.Logging;
using Model;
using Sandbox.Database;

namespace Repository.Repository.Todos
{
    public class TodoRepository : ITodoRepository
    {
        private readonly ILogger<TodoRepository> _logger;
        private readonly DatabaseConnection _databaseConnection;

        public TodoRepository(
            ILogger<TodoRepository> logger,
            DatabaseConnection databaseConnection
            )
        {
            _logger = logger;
            _databaseConnection = databaseConnection;
        }

        public async Task<int?> DeleteTodo(Todo todo)
        {
            try
            {
                string query = @"
                    DELETE FROM todo.UserTask
                    	WHERE TaskId = @todoId
                    
                    DELETE FROM todo.Task
                    	WHERE TaskId = @todoId
                    ";

                using (var connection = _databaseConnection.CreateConnection())
                {
                    return await connection.ExecuteAsync(query, todo);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"failed to delete todo {todo.TodoId}");
                return null;
            }
        }

        public async Task<IEnumerable<Todo>> ReadTodo()
        {
            string query = "SELECT TaskId as TodoId, [Name], [Description] FROM sandbox.todo.Task";

            using (var connection = _databaseConnection.CreateConnection())
            {
                var companies = await connection.QueryAsync<Todo>(query);
                return companies.ToList();
            }
        }

        public async Task<int?> InsertTodo(Todo todo)
        {
            string query = "INSERT INTO sandbox.todo.Task (Name, Description) VALUES (@Name, @Description)";

            using (var connection = _databaseConnection.CreateConnection())
            {
                return await connection.ExecuteAsync(query, todo);
            }
        }
    }
}
