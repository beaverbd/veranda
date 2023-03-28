using Microsoft.EntityFrameworkCore;

namespace Veranda.Common.Database;

public class ServiceDbContext : DbContext
{
    public ServiceDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSnakeCaseNamingConvention();
    }
}
