using System;

namespace MIW_CustomerAuthService.Core.Exceptions
{
    public class FailedLoginAttemptException : Exception
    {
        public FailedLoginAttemptException()
        {
            
        }
        
        public FailedLoginAttemptException(string message) : base(message)
        {
            
        }
    }
}