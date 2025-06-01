namespace PlantMonitorAPI.Services.Base;

using Microsoft.EntityFrameworkCore;
using PlantMonitorAPI.Database.Entities.Base;

public interface IServiceBase<TEntity>
    where TEntity : EntityBase
{
    Task SaveChangesAsync(CancellationToken cancellationToken);

    DbSet<TEntity> GetEntities();
    IQueryable<TEntity> GetEntitiesQuery();
}
