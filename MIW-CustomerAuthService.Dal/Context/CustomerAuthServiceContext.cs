using MIW_CustomerAuthService.Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace MIW_CustomerAuthService.Dal.Context
{
    public class CustomerAuthServiceContext : DbContext
    {
        public DbSet<Credentials> Credentials { get; set; }

        public CustomerAuthServiceContext(DbContextOptions<CustomerAuthServiceContext> options) : base(options)
        {
            
        }
    }
}