using Dapper;
using Sandbox.Database;

namespace Sandbox.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DatabaseConnection _databaseConnection;

        public TaskRepository(DatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }

        public async Task<IEnumerable<TaskEntity>> GetAll()
        {
            var query = "SELECT TaskId, [Name], [Description] FROM sandbox.todo.Task";

            using (var connection = _databaseConnection.CreateConnection())
            {
                var companies = await connection.QueryAsync<TaskEntity>(query);
                return companies.ToList();
            }
        }
    }
}
