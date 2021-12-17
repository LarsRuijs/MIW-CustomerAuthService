using MIW_CustomerAuthService.Dal.Models;
using MIW_CustomerAuthService.Grpc;

namespace MIW_CustomerAuthService.Api.Mappers
{
    public class AuthMapper
    {
        public static RegisterResponse BoolToRegisterResponse(bool registered)
        {
            return new()
            {
                Registered = registered
            };
        }

        public static LoginResponse StringToLoginResponse(string token)
        {
            return new()
            {
                Token = token
            };
        }

        public static Credentials CredentialsMessageToCredentials(CredentialsMessage credentialsMessage)
        {
            return new Credentials()
            {
                Email = credentialsMessage.Email,
                Password = credentialsMessage.Password
            };
        }
    }
}
