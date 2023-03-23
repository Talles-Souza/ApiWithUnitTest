using System.Runtime.Serialization;

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
