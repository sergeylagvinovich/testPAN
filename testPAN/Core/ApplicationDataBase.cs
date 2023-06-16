using Microsoft.EntityFrameworkCore;
using testPAN.Domain.Entity;

namespace testPAN.Core
{
    public class ApplicationDataBase:DbContext
    {
        public ApplicationDataBase(DbContextOptions<ApplicationDataBase> options)
            : base(options)
        {
            Database.EnsureCreated();

        }

        public DbSet<User> users { get; set; }

        public DbSet<UserRequest> userRequests { get; set; }

        public DbSet<Organization> organizations { get; set; }

    }
}
