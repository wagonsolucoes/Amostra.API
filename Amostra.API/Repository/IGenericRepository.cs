using System.Linq.Expressions;

namespace Amostra.API.Repository
{
    public interface IGenericRepository<T> where T: class
    {
        T GetValueById(string Id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
