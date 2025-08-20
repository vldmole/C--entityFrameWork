using System.Linq.Expressions;

namespace common.services.crud
{
    public interface IBasicCrudService<TEntity> where TEntity : class
    {
        TEntity Create(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(int id);

        List<TEntity> ReadAll(Expression<Func<TEntity, bool>> predicate, int page=0, int pageSize=10 );
        TEntity FindById(int id);

        void SaveChanges();
        void SaveChangesAsync();

    }
}