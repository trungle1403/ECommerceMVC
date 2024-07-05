namespace ECommerceMVC.Services
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetByID(string id);
        T Create(T entity); 
        void Update(T entity);
        void Delete(string id);
    }
}
