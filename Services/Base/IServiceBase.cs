namespace PlantMonitorAPI.Services.Base;

using Microsoft.EntityFrameworkCore;
using PlantMonitorAPI.Database.Entities.Base;

public interface IServiceBase<TEntity>
    where TEntity : EntityBase
{
    Task SaveChangesAsync(CancellationToken cancellationToken);

    Task<int> AddEntity(TEntity entity, CancellationToken cancellationToken);

    Task<TEntity?> GetEntityAsync(int entityId, CancellationToken cancellationToken);

    Task<bool> HasEntityAsync(int entityId, CancellationToken cancellationToken);

    /// <summary>
    /// Do modyfikacji entitisów
    /// </summary>
    DbSet<TEntity> GetEntities();

    /// <summary>
    /// Do czytania entiti
    /// </summary>
    IQueryable<TEntity> GetEntitiesQuery();
}
