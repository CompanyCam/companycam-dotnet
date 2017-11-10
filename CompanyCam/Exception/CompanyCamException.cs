using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyCam.Objects
{
    public class CompanyCamException : Exception
    {
        public CompanyCamException()
        {
        }

        public CompanyCamException(string message) : base(message)
        {
        }

        public CompanyCamException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
