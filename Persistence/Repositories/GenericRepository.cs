﻿using Domain.Models;

namespace Persistence.Repositories;

internal class GenericRepository<TEntity, TKey>(OrderIdentityDbContext context)
    : IGenericRepository<TEntity, TKey>
    where TEntity : BaseEntity<TKey>
{
    public void Add(TEntity entity) => context.Set<TEntity>().Add(entity);
    public void Delete(TEntity entity) => context.Set<TEntity>().Remove(entity);
    public void Update(TEntity entity) => context.Set<TEntity>().Update(entity);
    public async Task<TEntity?> GetAsync(TKey key) => await context.Set<TEntity>().FindAsync(key);
    public async Task<IEnumerable<TEntity>> GetAllAsync() => await context.Set<TEntity>().ToListAsync();
    public async Task<IEnumerable<TEntity>> GetAllAsync(ISpecifications<TEntity> specifications) =>
        await SpecificationsEvaluator.CreateQuery(context.Set<TEntity>(), specifications).ToListAsync();
    public async Task<TEntity?> GetAsync(ISpecifications<TEntity> specifications) =>
        await SpecificationsEvaluator.CreateQuery(context.Set<TEntity>(), specifications).AsNoTracking().FirstOrDefaultAsync();

    public async Task<int> CountAsync(ISpecifications<TEntity> specifications)
        => await SpecificationsEvaluator.CreateQuery(context.Set<TEntity>(), specifications).CountAsync();


}
