using Amostra.API.Data.Amostra;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Amostra.API.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AmostraContext _ctx;
        
        public GenericRepository(AmostraContext ctx) {
            _ctx = ctx;
        }

        public T GetValueById(string Id)
        {
            return _ctx.Set<T>().Find(Id);
        }

        public IEnumerable<T> GetAll()
        {
            return _ctx.Set<T>().ToList();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _ctx.Set<T>().Where(predicate);
        }

        public void Add(T entity)
        {
            _ctx.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _ctx.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            _ctx.Set<T>().Remove(entity);
        }
    }
}
