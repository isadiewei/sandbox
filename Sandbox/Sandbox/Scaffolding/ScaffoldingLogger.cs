using NLog;
using NLog.Extensions.Logging;
using NLog.Targets;
using Sandbox.Database;
using System.Runtime.CompilerServices;

namespace Sandbox.Scaffolding
{
    public static class ScaffoldingLogger
    {
        public static void ConfigureLogging(this ILoggingBuilder builder)
        {
            builder.ClearProviders();
            builder.AddNLog();
            
            //DatabaseTarget target = (DatabaseTarget)LogManager.Configuration.FindTargetByName("database") 
            //    ?? throw new ArgumentNullException("NLog target was not found in the configuration file");

            //target.ConnectionString = new DatabaseConnection().Settings.ConnectionString;

            //LogManager.ReconfigExistingLoggers();
        }
    }
}
