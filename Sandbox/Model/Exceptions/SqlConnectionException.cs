namespace Model.Exceptions
{
    public class SqlConnectionException : Exception
    {
        public SqlConnectionException() { }

        public SqlConnectionException(string message, Exception innerException) : base(message, innerException) { } 
    }
}
