using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Exceptions
{
    public class RemovingNotAllowedException : Exception
    {
        public RemovingNotAllowedException(string message) : base(message)
        {
            message = "At least 1 Class must remain.";
        }
    }
}
