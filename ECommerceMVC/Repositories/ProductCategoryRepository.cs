using ECommerceMVC.Data;
using ECommerceMVC.Services;

namespace ECommerceMVC.Repositories
{
    public class ProductCategoryRepository : Repository<Category>
    {
        public ProductCategoryRepository(EcommerceMvcContext context) : base(context)
        {
        }
    }
}
