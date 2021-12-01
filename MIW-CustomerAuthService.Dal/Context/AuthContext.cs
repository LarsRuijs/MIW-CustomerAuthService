using MIW_CustomerAuthService.Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace MIW_CustomerAuthService.Dal.Context
{
    public class AuthContext : DbContext
    {
        public DbSet<Credentials> Credentials { get; set; }

        public AuthContext(DbContextOptions<AuthContext> options) : base(options)
        {
            
        }
    }
}