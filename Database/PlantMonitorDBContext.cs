namespace PlantMonitorAPI.Database;

using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PlantMonitorAPI.Database.Entities;
using PlantMonitorAPI.Database.Entities.Base;

public class PlantMonitorDBContext(DbContextOptions<PlantMonitorDBContext> ctxOptions) : DbContext(ctxOptions)
{
    public DbSet<Plant> Plants { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (EntityEntry entry in ChangeTracker.Entries())
        {
            if (entry.Entity is EntityBase @base && entry.State == EntityState.Added)
            {
                @base.AddedDate = DateTime.UtcNow;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}
