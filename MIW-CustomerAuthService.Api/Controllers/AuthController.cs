using System;
using System.Threading.Tasks;
using Grpc.Core;
using MIW_CustomerAuthService.Core.Services.Interfaces;
using MIW_CustomerAuthService.Grpc;
using Microsoft.Extensions.Logging;
using MIW_CustomerAuthService.Api.Mappers;

namespace MIW_CustomerAuthService.Api.Controllers
{
    public class AuthController : AuthService.AuthServiceBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IAuthService _authService;

        public AuthController(ILogger<AuthController> logger, IAuthService authService)
        {
            _logger = logger;
            _authService = authService;
        }
        
        public override async Task<RegisterResponse> Register(CredentialsMessage message, ServerCallContext context)
        {
            _logger.LogInformation("Register invoked");
            try
            {
                return AuthMapper.BoolToRegisterResponse(
                    await _authService.Register(AuthMapper.CredentialsMessageToCredentials(message)));
            }
            catch (Exception e)
            {
                _logger.LogError("{E}", e);
                throw new RpcException(new Status(StatusCode.Internal, e.Message));
            }
        }

        public override async Task<LoginResponse> Login(CredentialsMessage message, ServerCallContext context)
        {
            _logger.LogInformation("Login invoked");
            try
            {
                return AuthMapper.StringToLoginResponse(
                    await _authService.Login(AuthMapper.CredentialsMessageToCredentials(message)));
            }
            catch (Exception e)
            {
                _logger.LogError("{E}", e);
                throw new RpcException(new Status(StatusCode.Internal, e.Message));
            }
        }
    }
}