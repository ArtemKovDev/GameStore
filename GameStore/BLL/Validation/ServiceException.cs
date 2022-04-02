using System;
using System.Collections.Generic;
using System.Text;

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
