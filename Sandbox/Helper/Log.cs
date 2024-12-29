using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    public class Log : ILog
    {
        public Log()
        {
        }

        public bool? Info(string message)
        {
            return false;
        }

        public bool? Error(Exception e, string message)
        {
            return false;
        }
    }
}
