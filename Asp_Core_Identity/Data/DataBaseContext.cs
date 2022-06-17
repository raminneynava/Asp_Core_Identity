using Asp_Core_Identity.Models.Entities;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Asp_Core_Identity.Data
{ 
    //
    public class DataBaseContext:IdentityDbContext<User,Role,string>
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityUserLogin<string>>().HasKey(x=>new { x.ProviderKey,x.LoginProvider});
            builder.Entity<IdentityUserRole<string>>().HasKey(x=>new { x.UserId,x.RoleId});
            builder.Entity<IdentityUserToken<string>>().HasKey(x=>new { x.UserId,x.LoginProvider});
        }
    }
}
