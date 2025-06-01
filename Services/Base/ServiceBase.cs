namespace PlantMonitorAPI.Services.Base;

using System.Threading.Tasks;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using PlantMonitorAPI.Database;
using PlantMonitorAPI.Database.Entities.Base;

public abstract class ServiceBase<TEntity>(PlantMonitorDBContext context) : IServiceBase<TEntity>
    where TEntity : EntityBase
{
    private readonly PlantMonitorDBContext _ctx = context;

    public DbSet<TEntity> Entities { get; } = context.Set<TEntity>();

    public IQueryable<TEntity> EntitiesQuery
    {
        get => this.Entities.AsExpandable();
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await this._ctx.SaveChangesAsync(cancellationToken);
    }

    public DbSet<TEntity> GetEntities() => this.Entities;
    public IQueryable<TEntity> GetEntitiesQuery() => this.EntitiesQuery;

}
