using Dapper;
using Model;
using Sandbox.Database;

namespace Repository.Repository.Task
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DatabaseConnection _databaseConnection;

        public TaskRepository(DatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }

        public async Task<IEnumerable<Todo>> GetAll()
        {
            string query = "SELECT TaskId, [Name], [Description] FROM sandbox.todo.Task";

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
