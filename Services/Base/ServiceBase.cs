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

    /// <summary>
    /// Do modyfikacji entitisów
    /// </summary>
    public DbSet<TEntity> Entities { get; } = context.Set<TEntity>();

    /// <summary>
    /// Do czytania entiti
    /// </summary>
    public IQueryable<TEntity> EntitiesQuery
    {
        get => this.Entities.AsExpandable();
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await this._ctx.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// Do modyfikacji entitisów
    /// </summary>
    public DbSet<TEntity> GetEntities() => this.Entities;

    /// <summary>
    /// Do czytania entiti
    /// </summary>
    public IQueryable<TEntity> GetEntitiesQuery() => this.EntitiesQuery;

    /// <summary>
    /// Dodaje jedno entity do bazy, od razu zapisuje
    /// </summary>
    /// <param name="entity">Entity do zapisania</param>
    /// <param name="cancellationToken"></param>
    /// <returns>ID</returns>
    public async Task<int> AddEntity(TEntity entity, CancellationToken cancellationToken)
    {
        var entityEntry = this.Entities.Add(entity);

        await this.SaveChangesAsync(cancellationToken);

        return entityEntry.Entity.Id;
    }

    public async Task<TEntity?> GetEntityAsync(int entityId, CancellationToken cancellationToken)
    {
        return await this.EntitiesQuery.Where(e => e.Id == entityId).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<bool> HasEntityAsync(int entityId, CancellationToken cancellationToken)
    {
        return await this.EntitiesQuery.Where(e => e.Id == entityId).AnyAsync(cancellationToken);
    }
}
