using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Exceptions
{
    public class SelectException : Exception
    {
        public SelectException()
        {
        }

        public SelectException(string message)
            : base(message)
        {
        }

        public SelectException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
