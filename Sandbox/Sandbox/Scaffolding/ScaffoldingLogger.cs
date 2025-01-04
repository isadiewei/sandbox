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
        }
    }
}
