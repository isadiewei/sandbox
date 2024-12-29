namespace Helper
{
    public interface ILog
    {
        public bool? Info(string message);
        public bool? Error(Exception e, string message);
    }
}
