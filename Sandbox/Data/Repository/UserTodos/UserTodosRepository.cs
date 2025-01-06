using Dapper;
using Microsoft.Extensions.Logging;
using Model;
using Sandbox.Database;

namespace Repository.Repository.UserTodos
{
    public class UserTodosRepository : IUserTodosRepository
    {
        private readonly ILogger<UserTodosRepository> _logger;
        private readonly DatabaseConnection _connection;
        
        public UserTodosRepository(
            ILogger<UserTodosRepository> logger,
            DatabaseConnection databaseConnection
            )
        {
            _logger = logger;
            _connection = databaseConnection;
        }

        public async Task<IEnumerable<Todo>?> GetAll(User user)
        {
            try
            {
                string sql = @"
                    SELECT 
                    		ut.TaskId,
                    		t.[Name],
                    		t.[Description]
                    	FROM todo.UserTask ut
                    	JOIN todo.Task t
                    		ON t.TaskId = ut.TaskId
                    	JOIN todo.[User] u
                    		ON u.UserId = ut.UserId
                    	WHERE u.UserId = @userId
                    ";

                using (var connection = _connection.CreateConnection())
                {
                    return await connection.QueryAsync<Todo>(sql, user);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, message: $"failure reading tasks for user {user.UserId}");
                return null;
            }
        }
    }
}
