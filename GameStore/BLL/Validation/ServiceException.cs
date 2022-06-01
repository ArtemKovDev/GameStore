using System;

namespace BLL.Validation
{
    public class ServiceException : Exception
    {
        public ServiceException() { }

        public ServiceException(string massage) : base(massage) { }

        public ServiceException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
