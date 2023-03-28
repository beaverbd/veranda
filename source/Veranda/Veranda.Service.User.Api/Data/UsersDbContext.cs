using Microsoft.EntityFrameworkCore;
using Veranda.Common.Database;

namespace Veranda.Service.User.Api.Data;

public class UsersDbContext : ServiceDbContext
{
    public UsersDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Entities.User>()
            .HasKey(x => x.Id);
        modelBuilder.Entity<Entities.User>()
            .HasIndex(x => x.PublicId)
            .IsUnique();
    }
}
