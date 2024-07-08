using ECommerceMVC.Data;
using ECommerceMVC.Services;

namespace ECommerceMVC.Repositories
{
    public interface IMenuRepository : IRepository<Menu>
    {

    }
    public class MenuRepository : Repository<Menu>, IMenuRepository
    {
        public MenuRepository(EcommerceMvcContext context) : base(context) { }
    }
}
