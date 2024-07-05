
using ECommerceMVC.Data;
using System.Data.Entity;

namespace ECommerceMVC.Services
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly EcommerceMvcContext _context;

        public Repository(EcommerceMvcContext context) { 
            _context = context;

        }

        public T Create(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity;
        }

        public void Delete(string id)
        {
            var entity = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetByID(string id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
        }
    }

 
}
