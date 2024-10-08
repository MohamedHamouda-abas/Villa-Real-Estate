using System.Linq.Expressions;

namespace VailaPlace.Repository.IRepository
{
    public interface IRepository
    {
        public interface IRepository<T> where T : class
        {
            // The T is the class which as ref for any object
            IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
            T Get(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false);
            void Add(T entity);
            void Remove(T entity);
            void RemoveRange(IEnumerable<T> entity);
        }
    }
}
