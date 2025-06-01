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

    public DbSet<SensorData> SensorData { get; set; }

    /// <summary>
    /// Przeciążenie dodaje datę dodania do bazy do entity
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigurePlantEntity();
    }
}

internal static class ModelBuilderExtensions
{
    internal static void ConfigurePlantEntity(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Plant>()
            .HasMany(p => p.SensorDataRecords)
            .WithOne(sd => sd.Plant)
            .HasForeignKey(sd => sd.PlantId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}
