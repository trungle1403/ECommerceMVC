using ECommerceMVC.Data;
using System.Data.Entity;

namespace ECommerceMVC.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EcommerceMvcContext _context;

        public UnitOfWork(EcommerceMvcContext context) { 
            _context = context;
        }
        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
