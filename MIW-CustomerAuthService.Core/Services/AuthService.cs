using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MIW_CustomerAuthService.Core.Services.Interfaces;
using MIW_CustomerAuthService.Dal.Context;
using MIW_CustomerAuthService.Dal.Models;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using MIW_CustomerAuthService.Core.Exceptions;
using BC = BCrypt.Net.BCrypt;

namespace MIW_CustomerAuthService.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly ILogger<AuthService> _logger;
        private readonly AuthContext _authContext;
        private readonly SigningCredentials _signingCredentials;
        private readonly JwtSecurityTokenHandler _tokenHandler;

        public AuthService(ILogger<AuthService> logger, AuthContext authContext, IConfiguration configuration)
        {
            _logger = logger;
            _authContext = authContext;
            _signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(
                        configuration.GetSection("AppSettings")["Secret"])), 
                SecurityAlgorithms.HmacSha256Signature);
            _tokenHandler = new JwtSecurityTokenHandler();
        }
        
        public async Task<string> Login(Credentials credentials)
        {
            Credentials result = await _authContext.Credentials.FirstOrDefaultAsync(a => a.Email == credentials.Email);
            
            // check account found and verify password
            if (credentials == null || !BC.Verify(credentials.Password, result.Password))
            {
                // authentication failed
                throw new FailedLoginAttemptException();
            }

            // authentication successful
            SecurityTokenDescriptor tokenDescriptor = new ()
            {
                SigningCredentials = _signingCredentials,
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("id", result.Id.ToString()),
                    new Claim(ClaimTypes.Email, result.Email)
                }),
                Expires = DateTime.Now.AddDays(7)
            };

            return _tokenHandler.WriteToken(_tokenHandler.CreateToken(tokenDescriptor));
        }

        public async Task<bool> Register(Credentials credentials)
        {
            Credentials result = await _authContext.Credentials.FirstOrDefaultAsync(a => a.Email == credentials.Email);
            
            if (result != null)
            {
                throw new FailedRegisterAttemptException();
            }

            Credentials newEntry = new()
            {
                Email = credentials.Email,
                Password = BC.HashPassword(credentials.Password)
            };

            await _authContext.Credentials.AddAsync(newEntry);
            await _authContext.SaveChangesAsync();
            _logger.LogInformation("Account created with email: {Email}", credentials.Email);
            return true;
        }
    }
}