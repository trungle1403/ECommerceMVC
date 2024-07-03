namespace ECommerceMVC.Services
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
