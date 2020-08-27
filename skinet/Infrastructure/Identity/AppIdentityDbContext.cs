using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Identity
{
    //Similar to dbcontext .. for identity table
    public class AppIdentityDbContext : IdentityDbContext
    {
        //there are more than 1 db context so we are specifying the type
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder); // to avoid issue with identity and promary key of the user
        }
    }
}
