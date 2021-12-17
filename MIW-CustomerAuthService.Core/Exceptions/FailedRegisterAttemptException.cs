using System;

namespace MIW_CustomerAuthService.Core.Exceptions
{
    public class FailedRegisterAttemptException : Exception
    {
        public FailedRegisterAttemptException()
        {
            
        }

        public FailedRegisterAttemptException(string message) : base(message)
        {
            
        }
    }
}