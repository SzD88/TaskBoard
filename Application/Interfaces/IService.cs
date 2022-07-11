using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

public interface IService<TEntity,TEntityCreate, TEntityUpdate> where TEntity : class where TEntityCreate : class where TEntityUpdate : class
{
    //  void Delete(TEntity entityToDelete);

    Task<TEntity> CreateAsync(TEntityCreate entity);
    Task DeleteAsync(object id);
    Task<IEnumerable<TEntity>> GetAllAsync(); // int pageNumber, int pageSize, string sortField, bool ascending, string filterBy

    Task<TEntity> GetByIDAsync(object id);
    //IEnumerable<TEntity> GetWithRawSql(string query,
    //    params object[] parameters);

    Task UpdateAsync(TEntityUpdate entityToUpdate);
}