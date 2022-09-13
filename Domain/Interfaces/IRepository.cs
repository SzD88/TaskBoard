public interface IRepository<TEntity> where TEntity : class
{ 
    Task <TEntity> CreateAsync(TEntity entity);
    Task DeleteAsync(Guid id);
    Task<IReadOnlyList<TEntity>> GetAllAsync();  
    Task<TEntity> GetByIDAsync(Guid id); 
    Task UpdateAsync(TEntity entityToUpdate);
}