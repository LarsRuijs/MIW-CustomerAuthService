using System.Threading.Tasks;
using MIW_CustomerAuthService.Core.Services.Interfaces;
using MIW_CustomerAuthService.Dal.Context;
using MIW_CustomerAuthService.Dal.Models;
using Microsoft.Extensions.Logging;

namespace MIW_CustomerAuthService.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly ILogger<AuthService> _logger;
        private readonly AuthContext _authContext;

        public AuthService(ILogger<AuthService> logger, AuthContext authContext)
        {
            _logger = logger;
            _authContext = authContext;
        }
        
        public Task<string> Login(string email, string password)
        {
            throw new System.NotImplementedException();
        }

        public Task<Credentials> Register(string email, string password)
        {
            throw new System.NotImplementedException();
        }
    }
}