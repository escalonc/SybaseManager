using System;

namespace SybaseManager
{
    public class SybaseManagerException : Exception
    {
        public SybaseManagerException(string message) : base(message)
        {
        }
    }
}
