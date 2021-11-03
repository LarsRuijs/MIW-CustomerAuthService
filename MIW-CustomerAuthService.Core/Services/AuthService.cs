using System.Threading.Tasks;
using MIW_CustomerAuthService.Core.Services.Interfaces;
using MIW_CustomerAuthService.Dal.Models;

namespace MIW_CustomerAuthService.Core.Services
{
    public class AuthService : IAuthService
    {
        public Task<string> Login(string email, string password)
        {
            throw new System.NotImplementedException();
        }

        public Task<Credentials> Register(string emial, string password)
        {
            throw new System.NotImplementedException();
        }
    }
}