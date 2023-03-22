using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Services.Exceptions
{
    [Serializable]
    public class ExceptionClass : Exception
    {
        public ExceptionClass()
        {
        }

        public ExceptionClass(string? message) : base(message)
        {
        }

        public ExceptionClass(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ExceptionClass(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
