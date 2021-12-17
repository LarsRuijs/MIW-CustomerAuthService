using System;
using System.Threading.Tasks;
using MIW_CustomerAuthService.Dal.Models;

namespace MIW_CustomerAuthService.Core.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> Login(Credentials credentials);

        Task<bool> Register(Credentials credentials);
    }
}