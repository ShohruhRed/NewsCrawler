using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ASPTryParsing.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options): base(options)
        {
                
        }
    }
}
