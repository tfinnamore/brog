using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Brog.Entities
{

    public class BrogDbContext : IdentityDbContext<User>
    {
     
        public BrogDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Article> Articles { get; set; }
    }
}
