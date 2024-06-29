namespace ECommerceMVC.Services
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByID(string id);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);  
        Task<T> DeleteAsync(string id);
    }
}
