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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Organization>(builder =>
            {
                builder.Property(x => x.id).ValueGeneratedOnAdd();
                builder.Property(x => x.pan).IsRequired();
            });

            modelBuilder.Entity<User>(builder =>
            {
                builder.Property(x => x.id).ValueGeneratedOnAdd();
                builder.Property(x => x.email).IsRequired();
                builder.HasMany(x => x.requests).WithOne(x => x.user).HasForeignKey(x => x.user_id);
            });

            modelBuilder.Entity<UserRequest>(builder =>
            {
                builder.Property(x => x.id).ValueGeneratedOnAdd();
                builder.Property(x => x.pan).IsRequired();
                builder.HasOne(x => x.user).WithMany(x => x.requests).HasForeignKey(x => x.user_id);
            });

        }

    }
}
