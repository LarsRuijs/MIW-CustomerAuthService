using System;
using System.Threading.Tasks;
using MIW_CustomerAuthService.Dal.Models;

namespace MIW_CustomerAuthService.Core.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> Login(string email, string password);

        Task<Credentials> Register(string email, string password);
    }
}