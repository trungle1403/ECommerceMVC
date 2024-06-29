
using ECommerceMVC.Data;

namespace ECommerceMVC.Services
{
    public class Repository<T>
    {
        private readonly EcommerceMvcContext _context;

        public Repository(EcommerceMvcContext context) { 
            _context = context;
        }

    }
}
